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
		List<GameObject> objects = new List<GameObject>();
		print(objects);
		objects.Add(droid);
		print(objects);
        Droid subject = droid.GetComponent<Droid>();

        //check if the player can catch the subject
        if(subject.name.Equals("Desarrollo de aplic. para Disp. Moviles"))
        {
            alert.SetActive(true);
            alert.GetComponentInChildren<Text>().text = "Alumno:\n Aun no puedes tomar esta materia...";
        }else{
            SceneTransitionManager.Instance.
                                  GoToScene(PocketDroidsConstants.SCENE_ARCAPTURE, objects);
        }
	}
}
