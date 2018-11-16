using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    [SerializeField] private GameObject gridSubject;

    string[,] subjectData = new string[,]
    { { "CALCULO DIFERENCIAL", "ACF-0901", "CB", "3", "2", "5" },
    { "CALCULO INTEGRAL", "ACF-0902", "CB", "3", "2", "5" },
        { "MATEMATICAS APLICADAS A LAS COMUNICACIONES", "TIE-1018", "IL", "3", "1", "4" },
        { "ANÁLISIS DE SEÑALES Y SIST. DE COMUNICACIÓN ", "TID-1004", "IL", "2", "3", "5" },
        { "FUNDAMENTOS DE REDES", "TIF-1013", "SC", "3", "2", "5" },
        { "REDES DE COMPUTADORAS", "TIF-1025", "SC", "3", "2", "5" },
        { "REDES EMERGENTES", "TIF-1026", "SC", "3", "2", "5" },
        { "ADMINISTRACIÓN Y SEGURIDAD DE REDES", "TIF-1003", "SC", "3", "2", "5" },
        { "INTEGRACIÓN HUMANO COMPUTADORA", "TIH-1016", "SC", "1", "3", "4" },
        { "FUNDAMENTOS DE PROGRAMACIÓN", "ACF-0901", "CB", "3", "2", "5" },
        { "CALCULO INTEGRAL", "ACF-0901", "CB", "3", "2", "5" },
        { "CALCULO INTEGRAL", "ACF-0901", "CB", "3", "2", "5" },
        { "CALCULO INTEGRAL", "ACF-0901", "CB", "3", "2", "5" },
        { "CALCULO INTEGRAL", "ACF-0901", "CB", "3", "2", "5" },
    };
    // Use this for initialization
    void Start () {
        populateGridSubject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void populateGridSubject(){
        for (int i = 0; i < subjectData.GetLength(0); i++){

            GameObject subject = Instantiate(gridSubject, transform);
            subject.GetComponent<SubjectGridButton>().SetNameText(subjectData[i, 0]);
            subject.GetComponent<SubjectGridButton>().SetIdText(subjectData[i, 1]);
            subject.GetComponent<SubjectGridButton>().SetType(subjectData[i,2]);
            subject.GetComponent<SubjectGridButton>().SetTheryTime(subjectData[i, 3]);
            subject.GetComponent<SubjectGridButton>().SetPracticeTimet(subjectData[i, 4]);
            subject.GetComponent<SubjectGridButton>().SetCredits(subjectData[i, 5]);


        }
    }
}
