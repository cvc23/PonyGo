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
        /*switch (PocketDroidsConstants.DROID_SELECTED)
        {
            case "ACF-0901": //calculo Diferencial
                Instantiate(droids[0], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case "AEF-1032": //Fundamentos de programacion
                Instantiate(droids[2], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case "ACF-0902": //Calculo Integral
                Instantiate(droids[1], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case "ACF-0903": //Algebra lineal
                Instantiate(droids[1], new Vector3(0, 0, 0), Quaternion.identity);
                break;
            default:
                break;
        }
        */

        for (int i = 0; i < droids.Length; i++){
            if(droids[i].Id.Equals(PocketDroidsConstants.DROID_SELECTED)){
                //print(PocketDroidsConstants.DROID_SELECTED);
                Instantiate(droids[i], new Vector3(0, 0, 0), Quaternion.identity);
                GameObject droid = GameObject.FindWithTag("Droid");
                droid.transform.Rotate(0, 180, 0);
                droid.transform.Translate(0.5f, 2.61f, -0.12f);
                nameSubject.text = droid.GetComponent<Droid>().Subject;

                //Place the object in the right position
                switch (droid.GetComponent<Droid>().ModelType)
                {
                    case "laptop": //Programación
                        droid.transform.Translate(0.6f, 0.32f, -0.12f);
                        break;
                    case "balanza": //ética
                        droid.transform.Translate(-0.6f, 0.4f, -0.12f);
                        break;
                    case "satellite": //telecomunicaciones
                        droid.transform.Translate(0.14f, 2.75f, -0.12f);
                        break;
                    case "dice": //probailidad
                        droid.transform.Translate(0.13f, 1.36f, -0.12f);
                        break;
                    case "ball": //ing de software
                        droid.transform.Translate(0.09f, 2.19f, -0.12f);
                        break;
                    case "trophy": //emprendedor
                        droid.transform.Translate(-0.1f, 0.34f, -0.12f);
                        break;
                    case "wifi": //redes inalámbricas
                        droid.transform.Translate(-0.3814f, 1.54f, 3.41f);
                        break;
                    case "android": //aplicaciones móviles
                        droid.transform.Translate(-0.06f, 2.2f, -0.12f);
                        break;
                    case "books": //investigación
                        droid.transform.Translate(1.7f, 0.23f, -4.25f);
                        break;
                    case "bank": //contabilidad
                        droid.transform.Translate(0.02f, 0.34f, -0.12f);
                        droid.transform.Rotate(0, -90, 0);
                        break;
                    case "plant": //desarrollo sustentable
                        droid.transform.Translate(0f, 0.34f, -0.12f);
                        break;
                    case "serverrack": //base de datos distribuidas
                        droid.transform.Translate(0.12f, 0.34f, -0.12f);
                        break;
                    case "server": //telecomunicaciones
                        droid.transform.Translate(-0.12f, 0.34f, -0.12f);
                        break;
                    case "apple": //sistemas operativos
                        droid.transform.Translate(0.05f, 2.08f, -0.12f);
                        droid.transform.Rotate(0, 270, 90);
                        break;
                    case "building": //practicas profesionales
                        droid.transform.Translate(-2.5f, 2.08f, 4.33f);
                        droid.transform.Rotate(-90, 180, 0);
                        break;
                    case "telephone": //telecomunicaciones
                        droid.transform.Translate(0f, 2.64f, -0.12f);
                        droid.transform.Rotate(0, -90, 0);
                        break;
                    case "bulb": //interaccion huamno computadora
                        droid.transform.Translate(0.03f, 0.34f, -0.12f);
                        break;
                    case "ironman": //interaccion huamno computadora
                        droid.transform.Translate(-3.12f, 0.34f, -0.12f);
                        break;
                    case "r2d2": //ingenieria del conocimiento
                        droid.transform.Translate(-0.12f, 0.43f, -0.12f);
                        break;
                    case "atm": //ingenieria del conocimiento
                        droid.transform.Translate(0.14f, 2.75f, -0.12f);
                        break;
                    default:
                        break;
                }
                break;
            }
        }


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
        // Debug.Log("Se registro en Analytics, ceamos si en DB");

        string id_matAtrapada = droid.GetComponent<Droid>().Id;
        PocketDroidsConstants.Materia materia = checharAtrapadas(id_matAtrapada);
        
        DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;
        dbref. 
            Child("alumnos").
            Child(PocketDroidsConstants.USER_ID).
            Child("materias").
            Child("Atrapadas").
            Child(id_matAtrapada).
            SetRawJsonValueAsync(materia.SaveToString2());

        Invoke("MoveToWorldScene", 2.0f);
    }

    public void MoveToAR(){
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_ARCAPTURE, new List<GameObject>());
    }

    private void MoveToWorldScene()
    {
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, new List<GameObject>());
    }

    private PocketDroidsConstants.Materia checharAtrapadas(string id_matAtrapada){
        foreach (var materia in PocketDroidsConstants.CAPTUREDPRO_SUBJECTS)
                if (id_matAtrapada == materia.id_materia) {
                    materia.atrapadas++;
                    return  materia;
                }
        PocketDroidsConstants.Materia nvaMateria = new PocketDroidsConstants.Materia(
                    id_matAtrapada,
                    1
                );
        PocketDroidsConstants.CAPTUREDPRO_SUBJECTS.Add(nvaMateria);

        return nvaMateria;
    }
    
}
