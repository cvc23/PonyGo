using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamSubjectSceneManager : MonoBehaviour
{
    [SerializeField] private Button answer1;
    [SerializeField] private Button answer2;
    [SerializeField] private Button answer3;
    [SerializeField] private Text question;
    [SerializeField] private string correctAswer;
    [SerializeField] private GameObject correctScreen;
    [SerializeField] private GameObject wrongScreen;


    // Use this for initialization
    void Start()
    {
        //Check how many attemps the user has
        //Get data from firebsae with the key 
        //PocketDroidsConstants.SUBJECTID_SELECTED;
        answer1.GetComponentInChildren<Text>().text = "Si";
        answer2.GetComponentInChildren<Text>().text = "Tal vez";
        answer3.GetComponentInChildren<Text>().text = "No";
        correctAswer = "No";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(Button button){
        string answer = button.GetComponentInChildren<Text>().text;
        if(answer.Equals(correctAswer)){
            print("correcto");
            correctScreen.SetActive(true);
        }
        else{
            print("incorrecto!");
            wrongScreen.SetActive(true);
        }
        Invoke("MoveToTrainingScene", 2.5f);
    
    }
    private void MoveToTrainingScene()
    {
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_TRAINING, new List<GameObject>());
    }
}
