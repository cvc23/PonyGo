using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PocketDroidsConstants {

	public static string SCENE_WORLD = "World";
    public static string SCENE_TUTORIAL = "Tutorial";
    public static string SCENE_CAPTURE = "Capture";
    public static string SCENE_TRAINING = "Training";
    public static string SCENE_ABOUTSUBJECT = "AboutSubject";
    public static string SCENE_EXAMSUBJECT = "ExamSubject";
    public static string SCENE_ARCAPTURE = "ARCapture";


    public static string USER_ID = "none";
    public static string USER_NICKNAME = "";
    public static List<string> APROVED_SUBJECTS = new List<string>();

    public static int GOAL_SUBJECTS = 51;
    public static List<Materia> CAPTUREDPRO_SUBJECTS = new List<Materia>();
       public class Materia
    {
        public string id_materia;
        public int atrapadas;
        public int intentos;
        public Materia(string id_materia, int atrapadas)
        {
            this.id_materia = id_materia;
            this.atrapadas = atrapadas;
            this.intentos = 0;
        }
        public Materia(string id_materia, int atrapadas, int intentos)
        {
            this.id_materia = id_materia;
            this.atrapadas = atrapadas;
            this.intentos = intentos;
        }

        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
        public string SaveToString2()
        {
            return "{ \"atrapadas\":"+this.atrapadas+",\"intentos\":"+this.intentos+"}";
        }
    }

    public static string TAG_DROID = "Droid";
	public static string TAG_OVERRIDE_ORB = "OverrideOrb";
    public static string DROID_SELECTED = "none";
    public static string SUBJECT_SELECTED = "none";
    public static string SUBJECT_SELECTED_ID = "none";
    public static string SUBJECT_SELECTED_TH = "0";
    public static string SUBJECT_SELECTED_PH = "0";
    public static string SUBJECT_SELECTED_CREDITS = "0";
    public static int PLAYER_STEPS = 0;
    public static List<string> SUBJECT_QUESTIONS = new List<string>();


    public static int THROWS = 3;

}
