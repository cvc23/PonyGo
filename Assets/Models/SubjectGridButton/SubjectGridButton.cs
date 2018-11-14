using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectGridButton : MonoBehaviour
{

    [SerializeField] private Text nameText;
    [SerializeField] private Text idText;

    public void SetNameText(string name){
        nameText.text = name;
    }

    public void SetIdText(string id)
    {
        idText.text = id;
    }

    public string GetIdText(){
        return idText.text;
    }

    public string GetNameText()
    {
        return nameText.text;
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(){
        //SET VARIABLE FOR EXAM
        GameObject obj = this.gameObject;
        SubjectGridButton btn = obj.GetComponent<SubjectGridButton>();
        PocketDroidsConstants.SUBJECT_SELECTED = btn.GetNameText();
        PocketDroidsConstants.SUBJECTID_SELECTED = btn.GetIdText();
        List<GameObject> objects = new List<GameObject>();
            SceneTransitionManager.
                                  Instance.GoToScene(PocketDroidsConstants.SCENE_ABOUTSUBJECT, objects);
    }
}
