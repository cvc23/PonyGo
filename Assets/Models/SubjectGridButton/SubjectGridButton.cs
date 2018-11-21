using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SubjectGridButton : MonoBehaviour
{

    [SerializeField] private Text nameText;
    [SerializeField] private Text idText;
    [SerializeField] private Text type;
    [SerializeField] private Text theoryTime;
    [SerializeField] private Text practiceTime;
    [SerializeField] private Text credits;
    [SerializeField]
    private List<string> questions = new List<string>();

    public void SetQuestions(string data){
        questions.Add(data);
    }

    public void SetNameText(string name){
        nameText.text = name;
    }

    public void SetIdText(string id)
    {
        idText.text = id;
    }

    public void SetType(string type)
    {
        this.type.text = type;
    }
    public void SetTheryTime(string a)
    {
        theoryTime.text = a;
    }
    public void SetPracticeTimet(string a)
    {
        practiceTime.text = a;
    }
    public void SetCredits(string a)
    {
        credits.text = a;
    }

    public string GetIdText(){
        return idText.text;
    }

    public string GetNameText()
    {
        return nameText.text;
    }

    public string GetTypet()
    {
        return type.text;
    }
    public string GetTheoryTime()
    {
        return theoryTime.text;
    }
    public string GetPracticeTime()
    {
        return practiceTime.text;
    }
    public string GetCredits()
    {
        return credits.text;
    }

    public string GetQuestion(){
        System.Random rnd = new System.Random();
        return questions[rnd.Next(0, 2)];
    }


    public void OnClick(){
        //SET VARIABLE FOR EXAM
        GameObject obj = this.gameObject;
        SubjectGridButton btn = obj.GetComponent<SubjectGridButton>();
        PocketDroidsConstants.SUBJECT_SELECTED = btn.GetNameText();
        PocketDroidsConstants.SUBJECTID_SELECTED = btn.GetIdText();
        PocketDroidsConstants.SUBJECTID_SELECTED_TH = btn.GetTheoryTime();
        PocketDroidsConstants.SUBJECTID_SELECTED_PH = btn.GetPracticeTime();
        PocketDroidsConstants.SUBJECTID_SELECTED_CREDITS = btn.GetCredits();
        PocketDroidsConstants.SUBJECTID_SELECTED_QUESTION = btn.GetQuestion();

        List<GameObject> objects = new List<GameObject>();
            SceneTransitionManager.
                                  Instance.GoToScene(PocketDroidsConstants.SCENE_ABOUTSUBJECT, objects);
    }
}
