using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class CaptureSceneManager : PocketDroidsSceneManager {

	[SerializeField] private int maxThrowAttempts = 3;
	[SerializeField] private GameObject orb;
	[SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Droid[] droids;
    [SerializeField] private Text nameSubject; 

    private int currentThrowAttempts;
	private CaptureSceneStatus status = CaptureSceneStatus.InProgress;

	public int MaxThrowAttempts {
		get { return maxThrowAttempts; }
	}

	public int CurrentThrowAttempts {
		get { return currentThrowAttempts; }
	}

	public CaptureSceneStatus Status {
		get { return status; }
	}

	private void Start() {
		CalculateMaxThrows();
		currentThrowAttempts = maxThrowAttempts;
        //display a subject on the scene
        switch (PocketDroidsConstants.DROID_SELECTED)
        {
            case "Especialidad1":
                Instantiate(droids[0], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case "Especialidad2":
                Instantiate(droids[1], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case "Desarrollo de aplic. para Disp. Moviles":
                Instantiate(droids[2], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            default:
                break;
        }
        print(PocketDroidsConstants.DROID_SELECTED);
        GameObject droid = GameObject.FindWithTag("Droid");
        droid.transform.Rotate(0, 180, 0);
        droid.transform.Translate(0.5f, 2.61f, -0.12f);
        nameSubject.text = droid.GetComponent<Droid>().Subject;

    }

	private void testTransition() {
		List<GameObject> objs = new List<GameObject>();
		SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, objs);
	}

	private void CalculateMaxThrows() {
		
	}

	public void OrbDestroyed() {
		currentThrowAttempts--;
		if (currentThrowAttempts <= 0) {
			if (status != CaptureSceneStatus.Successful) {
                status = CaptureSceneStatus.Failed;
                Invoke("MoveToWorldScene", 2.0f);
            }
		}
		else {
			Instantiate(orb, spawnPoint, Quaternion.identity);
		}
	}

	public override void playerTapped(GameObject player) {
		print("CaptureSceneManager.playerTapped activated");
	}

	public override void droidTapped(GameObject droid) {
		print("CaptureSceneManager.droidTapped activated");
	}

	public override void droidCollision(GameObject droid, Collision other) {
		status = CaptureSceneStatus.Successful;

        Firebase.Analytics.FirebaseAnalytics.LogEvent(
            "AtrapoMateria", "materiaName", PocketDroidsConstants.DROID_SELECTED
        );
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
            Firebase.Analytics.FirebaseAnalytics.EventLevelUp
        );
        Debug.Log("Se registro en Analytics, ceamos si en DB");

        DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;

        Materia materiaAtrapada = new Materia(
            droid.GetComponent<Droid>().Id,
            droid.GetComponent<Droid>().Subject
            );
        string json = JsonUtility.ToJson(materiaAtrapada);

        dbref. //Child("testeo").
            Child("alumnos").
            Child(PocketDroidsConstants.USER_ID).
            Child("materias").
            Child("Atrapadas").
            Push().
            SetRawJsonValueAsync(json);

        PocketDroidsConstants.CAPTURED_SUBJECTS.Add(droid.GetComponent<Droid>().Id);

        Debug.Log("10-04, agregado");

        Invoke("MoveToWorldScene", 2.0f);
    }

    public void MoveToAR(){
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_ARCAPTURE, new List<GameObject>());
    }

    private void MoveToWorldScene()
    {
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, new List<GameObject>());
    }

    public class Materia
    {
        public string id_materia;
        public string nombre;

        public Materia(string username, string email)
        {
            this.id_materia = username;
            this.nombre = email;
        }
    }
}
