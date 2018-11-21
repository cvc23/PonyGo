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

    public List<string> GetQuestions(){
        return questions;
    }


    public void OnClick(){
        //SET VARIABLE FOR EXAM
        GameObject obj = this.gameObject;
        SubjectGridButton btn = obj.GetComponent<SubjectGridButton>();
        PocketDroidsConstants.SUBJECT_SELECTED = btn.GetNameText();
        PocketDroidsConstants.SUBJECT_SELECTED_ID = btn.GetIdText();
        PocketDroidsConstants.SUBJECT_SELECTED_TH = btn.GetTheoryTime();
        PocketDroidsConstants.SUBJECT_SELECTED_PH = btn.GetPracticeTime();
        PocketDroidsConstants.SUBJECT_SELECTED_CREDITS = btn.GetCredits();
        PocketDroidsConstants.SUBJECT_QUESTIONS = btn.GetQuestions();

        List<GameObject> objects = new List<GameObject>();
            SceneTransitionManager.
                                  Instance.GoToScene(PocketDroidsConstants.SCENE_ABOUTSUBJECT, objects);
    }
}
