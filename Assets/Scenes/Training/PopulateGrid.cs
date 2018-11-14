using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour {
    [SerializeField]private GameObject gridSubject;

	// Use this for initialization
	void Start () {
        populateGridSubject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void populateGridSubject(){
        for (int i = 0; i < 52; i++){

            GameObject subject = Instantiate(gridSubject, transform);
            subject.GetComponent<SubjectGridButton>().SetIdText("ACF-0901");
            subject.GetComponent<SubjectGridButton>().SetNameText("Calculo Diferencial");
        }
    }
}
