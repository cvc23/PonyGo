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
        string materia_id = PocketDroidsConstants.SUBJECT_SELECTED_ID;
        DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;

        if (correct >= 2)
        {
            correctScreen.SetActive(true);
            correctScreen.GetComponentInChildren<Text>().text = "Felicidades! aprobaste la materia!";

            
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp);
            Firebase.Analytics.FirebaseAnalytics.LogEvent("AproboMateria", "materia_id", materia_id );


            MateriaAP materiaAprobada = new MateriaAP(
                System.Int32.Parse( PocketDroidsConstants.SUBJECT_SELECTED_CREDITS),
                System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );
            string json = JsonUtility.ToJson(materiaAprobada);

            dbref.
            Child("alumnos").
            Child(PocketDroidsConstants.USER_ID).
            Child("materias").
            Child("Aprobadas").
            Child(materia_id).
            SetRawJsonValueAsync(json);

            PocketDroidsConstants.APROVED_SUBJECTS.Add(materia_id);

        }
        else
        {
            wrongScreen.SetActive(true);
            //verify how many times the user has taken this exam
            Firebase.Analytics.FirebaseAnalytics.LogEvent("ReproboMateria", "materia_id", materia_id );
            foreach (var materia in PocketDroidsConstants.CAPTUREDPRO_SUBJECTS)
            {   
                if (materia_id == materia.id_materia)
                {
                    materia.intentos++;

                    dbref.
                    Child("alumnos").
                    Child(PocketDroidsConstants.USER_ID).
                    Child("materias").
                    Child("Atrapadas").
                    Child(materia_id).
                    Child("intentos").
                    SetValueAsync(materia.intentos);
                    
                    if (materia.intentos > 3)
                    {
                        //you fail and you have to quit the game
                        wrongScreen.GetComponentInChildren<Text>().text = "Lastima... saca ficha el siguiente semestre...";
                        Firebase.Analytics.FirebaseAnalytics.LogEvent("ReproboEspecial", "materia_id", materia_id );
                    }
                    else
                    {
                        //the user still has another chance
                        wrongScreen.GetComponentInChildren<Text>().text = "Sigue estudiando";
                    }
                    
                }
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

    public class MateriaAP{
        public int creditos;
        public string fecha_aprobacion;

        public MateriaAP(int creditos, string fecha_aprobacion){
            this.creditos = creditos;
            this.fecha_aprobacion = fecha_aprobacion;
        }
    }

}
