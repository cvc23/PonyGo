using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTrainingScene : MonoBehaviour {

    public void OnClick(){
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_TRAINING, objects);

    }
}
