using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnScene : MonoBehaviour {

    public void OnClick(){
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_WORLD, objects);

    }
}
