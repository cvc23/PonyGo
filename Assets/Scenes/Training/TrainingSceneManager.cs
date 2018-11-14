using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickReturnButton()
    {
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, objects);

    }
}
