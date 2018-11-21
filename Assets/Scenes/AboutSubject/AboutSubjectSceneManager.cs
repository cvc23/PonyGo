using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutSubjectSceneManager : MonoBehaviour {
    [SerializeField] private Text nameText;
    [SerializeField] private Text infoText;
    [SerializeField] private Image subjectImage;


	// Use this for initialization
	void Start () {
        //GET DATA FROM FIREBASE 
        //subjectImage SETIMAGE
        nameText.text = PocketDroidsConstants.SUBJECT_SELECTED;
        infoText.text = "Datos generales de la materia\n"+
            "Numero de horas teoricas: " + PocketDroidsConstants.SUBJECT_SELECTED_TH + "\n"
            + "Numero de horas practicas: " + PocketDroidsConstants.SUBJECT_SELECTED_PH+"\n"
            +"Numero creditos: " + PocketDroidsConstants.SUBJECT_SELECTED_CREDITS + "\n";


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickTrainingButton(){
        //SET VARIABLE FOR EXAM
        PocketDroidsConstants.SUBJECT_SELECTED = nameText.text;
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_EXAMSUBJECT, objects);

    }

    public void OnClickReturnButton()
    {
        //SET VARIABLE FOR EXAM
        PocketDroidsConstants.SUBJECT_SELECTED = nameText.text;
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_TRAINING, objects);

    }
}
