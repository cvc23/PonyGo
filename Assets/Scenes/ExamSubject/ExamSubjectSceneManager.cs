using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class ExamSubjectSceneManager : MonoBehaviour
{
    [SerializeField] private Button answer1;
    [SerializeField] private Button answer2;
    [SerializeField] private Button answer3;
    [SerializeField] private Text question;
    private string correctAswer;
    [SerializeField] private GameObject correctScreen;
    [SerializeField] private GameObject wrongScreen;
    [SerializeField] private Text questionNumber;
    private int num = 0;
    private int correct = 0;


    // Use this for initialization
    void Start()
    {
        //Check how many attemps the user has
        //Get data from firebsae with the key 
        //PocketDroidsConstants.SUBJECTID_SELECTED;
        //First Question....
        questionNumber.text = (num + 1) + " de 3";
        question.text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[0];
        answer1.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[1];
        answer2.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[2];
        answer3.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[3];
        correctAswer = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[4];

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(Button button){
        num++;

        if(num <3){

            checkAnswer(button.GetComponentInChildren<Text>().text);
            Invoke("HideAlertMessage", 1f);
            Invoke("NextQuestion", 1f);

        }
        if(num==3){
            checkAnswer(button.GetComponentInChildren<Text>().text);
            Invoke("HideAlertMessage", 1f);
            Invoke("checkResult", 1.5f);
        }
  
    }

    private void checkResult(){
        if (correct >= 2)
        {
            correctScreen.SetActive(true);
            correctScreen.GetComponentInChildren<Text>().text = "Felicidades! aprobaste la materia!";
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp);
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
                "AproboMateria", "materia_id", PocketDroidsConstants.SUBJECT_SELECTED_ID
            );

            DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;

            Materia materiaAprobada = new Materia(
            PocketDroidsConstants.SUBJECT_SELECTED_ID,
            PocketDroidsConstants.SUBJECT_SELECTED_CREDITS
            );
            string json = JsonUtility.ToJson(materiaAprobada);

            dbref.
            Child("alumnos").
            Child(PocketDroidsConstants.USER_ID).
            Child("materias").
            Child("Aprobadas").
            Push().
            SetRawJsonValueAsync(json);
        }
        else
        {
            wrongScreen.SetActive(true);
            //verify how many times the user has taken this exam
            int attempts = 0;
            if (attempts > 3)
            {
                //you fail and you have to quit the game
                wrongScreen.GetComponentInChildren<Text>().text = "Lastima... saca ficha el siguiente semestre...";
            }
            else
            {
                //the user still has another chance
                wrongScreen.GetComponentInChildren<Text>().text = "Sigue estudiando";

            }

        }
        Invoke("MoveToTrainingScene", 1.5f);

    }

    private void checkAnswer(string answer){
        if (answer.Equals(correctAswer))
        {
            print("correcto");
            correctScreen.SetActive(true);
            correct++;
        }
        else
        {
            print("incorrecto!");
            wrongScreen.SetActive(true);
        }
    }


    private void NextQuestion(){
        questionNumber.text = (num + 1) + " de 3";
        question.text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[0];
        answer1.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[1];
        answer2.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[2];
        answer3.GetComponentInChildren<Text>().text = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[3];
        correctAswer = PocketDroidsConstants.SUBJECT_QUESTIONS[num].Split('.')[4];
    }

    private void HideAlertMessage(){
        correctScreen.SetActive(false);
        wrongScreen.SetActive(false);
    }
    private void Return(){
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_ABOUTSUBJECT, new List<GameObject>());
    }

    private void MoveToTrainingScene()
    {
        SceneTransitionManager.Instance.GoToScene(PocketDroidsConstants.SCENE_TRAINING, new List<GameObject>());
    }

    public class Materia
    {
        public string id_materia;
        public string creditos;

        public Materia(string username, string email)
        {
            this.id_materia = username;
            this.creditos = email;
        }
    }
}
