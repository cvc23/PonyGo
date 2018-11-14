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
        infoText.text = "Aqui va la descripcion de la materia Sed " +
            "ut perspiciatis, unde omnis iste natus error sit " +
            "voluptatem accusantium doloremque laudantium, totam " +
            "rem aperiam eaque ipsa, quae ab illo inventore veritatis " +
            "et quasi architecto beatae vitae dicta sunt, explicabo. " +
            "Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur" +
            " aut odit aut fugit, sed quia consequuntur magni dolores eos, " +
            "qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui " +
            "dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed" +
            "quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore magnam " +
            "aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum " +
            "exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid " +
            "ex ea commodi consequatur? Quis autem vel eum iure reprehenderit," +
            "qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel" +
            " illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? ";

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
