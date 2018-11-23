using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    [SerializeField] private GameObject gridSubject;

    string[,] subjectData = new string[,]
        { 
            { "Calculo diferencial", "ACF-0901", "CB", "3", "2", "5", "¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Calculo integral", "ACF-0902", "CB", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Mtematicas aplicadas a las comunicaciones", "TIE-1018", "IL", "3", "1", "4","¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Analisis de señales y sist. de comunicaciones", "TID-1004", "IL", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Fundamentos de redes", "TIF-1013", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Redes de computadoras", "TIF-1025", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Rdes emergentes", "TIF-1026", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Administracion y seguridad de redes", "TIF-1003", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Interaccion humano computadora", "TIH-1016", "SC", "1", "3", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            
            { "Fundamentos de programacion", "ACF-0901", "CB", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Programación orientada a objetos", "AEB-1054", "SC", "1", "4", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Estructuras y organizacion de datos", "TID-1012", "SC", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Programacion II", "TIB-1024", "SC", "1", "4", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Telecomunicaciones", "TIF-1029", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Desarrollo de emprendedores", "TID-1010", "EA", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Desarrollo de aplic. para disp. moviles", "AEB-1011", "SC", "1", "4", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Auditorias en tecnologias de la informacion", "TIC-1006", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Servicio social", "-", "-", "-", "-", "10" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },

            { "Matematicas discretas I", "TIF-1019", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Matematicas discretas II", "TIF-1020", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Fundamentos de base de datos", "AEF-1031", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller de base de datos", "AEH-1063", "SC", "1", "3", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Programacion web", "AEB-1055", "SC", "1", "4", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller de programacion avanzada", "SOV-1704", "SC", "0", "5", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Arquitectura y diseño de software", "SOD-1701", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Pruebas y validacion de software", "SOD-1702", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },

            { "Introduccion a las tics", "TIP-1017", "SC", "3", "0", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Algebra lineal", "ACF-0903", "CD", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Probabilidad y estadistica", "AEF-1052", "II", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Matematicas para la toma de decisiones", "TIF-1021", "II", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Administracion de proyectos", "TIF-1001", "SC", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller de investigacion", "ACA-0909", "SC", "0", "4", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller d einvestigacion II", "ACA-0910", "SC", "0", "4", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller de desarrollo agil de software", "SOD-1703", "SC", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Emprendedor de negocios de ti", "SOV-1705", "SC", "0", "5", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },

            { "Taller de etica", "ACA-0907", "SC", "0", "4", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Contabilidad y costos", "TIF-1009", "EA", "3", "2", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Administracion gerencial", "TIC-1002", "EA", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Circuitos electricos y electronicos", "TID-1008", "IL", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Arquitectura de computadoras", "TID-1005", "IL", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Sistemas operativos I", "AEC-1061", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Sistemas operativos II", "AEC-1062", "SC", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Ingenieria del conocimiento", "TIC-1015", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Actividades complementarioas", "-", "-", "0", "0", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },

            { "Fundamentos de investigacion", "ACC-0906", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Desarrollo sustentable", "ACD-0908", "IB", "2", "3", "5" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Electicidad y magnetismo", "TIC-1011", "CB", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Ingenieria de software", "TIF-1014", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Taller de ing. de software", "TIC-1027", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Tecnologías inalambricas", "TIC-1029", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Negocios electronicos I", "TIC-1022", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Negocios electronicos II", "TIC-1023", "SC", "2", "2", "4" ,"¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" },
            { "Residencias profesionales", "-", "-", "0", "0", "10","¿Cuantos creditos obtienes con esta materia?.1.5.3.5", "¿En que semestre tomas esta materia?.1.5.3.1", "¿A qué academia pertenece la materia?.CB.SC.TIC.CB" }

    };
    // Use this for initialization
    void Start () {
        populateGridSubject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private List<string> subjects = new List<string>();
    private List<string> subjects = PocketDroidsConstants.CAPTURED_SUBJECTS;

    private void populateGridSubject(){

        //Change this list with the real static list...
        subjects.Add("ACC-0906");
        subjects.Add("TIC-1002");
        subjects.Add("ACD-0908");
        subjects.Add("TIF-1019");

        for (int i = 0; i < subjects.Count; i++){
            for (int j = 0; j < subjectData.GetLength(0); j++){

                if (string.Equals(subjects[i], subjectData[j,1])){
                    print("son iguales: " + subjects[i] + ", " + subjectData[j, 1]);
                    GameObject subject = Instantiate(gridSubject, transform);
                    subject.GetComponent<SubjectGridButton>().SetNameText(subjectData[j, 0]);
                    subject.GetComponent<SubjectGridButton>().SetIdText(subjectData[j, 1]);
                    subject.GetComponent<SubjectGridButton>().SetType(subjectData[j, 2]);
                    subject.GetComponent<SubjectGridButton>().SetTheryTime(subjectData[j, 3]);
                    subject.GetComponent<SubjectGridButton>().SetPracticeTimet(subjectData[j, 4]);
                    subject.GetComponent<SubjectGridButton>().SetCredits(subjectData[j, 5]);
                    subject.GetComponent<SubjectGridButton>().SetQuestions(subjectData[j, 6]);
                    subject.GetComponent<SubjectGridButton>().SetQuestions(subjectData[j, 7]);
                    subject.GetComponent<SubjectGridButton>().SetQuestions(subjectData[j, 8]);
                }
            }

        }

    }
}
