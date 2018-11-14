﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager> {

	private AsyncOperation sceneAsync;

	public void GoToScene(string sceneName, List<GameObject> objectsToMove) {
		StartCoroutine(LoadScene(sceneName, objectsToMove));
	}

	private IEnumerator LoadScene(string sceneName, List<GameObject> objectsToMove)
	{
		SceneManager.LoadSceneAsync(sceneName);
	
		string oldScene = SceneManager.GetActiveScene().name;
		SceneManager.sceneLoaded += (newScene, mode) => 
			{ 
//				SceneManager.UnloadSceneAsync(oldScene);
				SceneManager.SetActiveScene(newScene);
			};
		Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);
		foreach (GameObject obj in objectsToMove) {
            if (obj.tag == "Droid")
            {
                Droid droid = obj.GetComponent<Droid>();
                PocketDroidsConstants.DROID_SELECTED = droid.Subject;
                print(droid.Subject);
            }
            SceneManager.MoveGameObjectToScene(obj, sceneToLoad);
		}
		yield return null;
	}
}
