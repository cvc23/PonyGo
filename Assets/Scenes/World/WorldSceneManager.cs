using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSceneManager : PocketDroidsSceneManager {
	private GameObject droid;
	private AsyncOperation loadScene;
    [SerializeField] private GameObject alert;
    
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void playerTapped(GameObject player) {
		
	}

	public override void droidTapped(GameObject droid) {
        //		SceneManager.LoadScene(PocketDroidsConstants.SCENE_CAPTURE);

        if (checkCapturedSubjects(droid.GetComponent<Droid>().RequiredSubject))
            GoToAdventure(droid);
        else
            StayHere();
    }


    public bool checkCapturedSubjects(string previousSub)
    {
        if (previousSub == "none")
            return true;
        else
            foreach (var matAtrapada in PocketDroidsConstants.CAPTUREDPRO_SUBJECTS)
                if (previousSub == matAtrapada.id_materia) return true;
        return false;
    }


    public void GoToAdventure(GameObject droid)
    {
        List<GameObject> objects = new List<GameObject>();
        print(objects);
        objects.Add(droid);
        print(objects);
        SceneTransitionManager.Instance.
            GoToScene(PocketDroidsConstants.SCENE_CAPTURE, objects);
    }
    public void StayHere()
    {
        Debug.Log("no tienes los requerimientos");
        alert.SetActive(true);
        alert.GetComponentInChildren<Text>().text = "Alumno:\n Aun no puedes tomar esta materia...";
    }

}
