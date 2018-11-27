using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;
using UnityEngine.Assertions;
using System;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class StepCounter : MonoBehaviour {

    [SerializeField] private Text StepText;
    [SerializeField] private Text DistanceText;
    private Pedometer pedometer;

    private void Start() {
        // Create a new pedometer
        pedometer = new Pedometer(OnStep);
        // Reset UI
        //Charging number of steps from firebase
        string stepsRef =   "alumnos/" +
                            PocketDroidsConstants.USER_ID +
                            "/system/pasosCaminados";

        FirebaseDatabase.DefaultInstance
            .GetReference(stepsRef)
            .GetValueAsync()
            .ContinueWith(dbtask =>
            {
                if (dbtask.IsFaulted){
                    Debug.LogError("no está lo que quieres");
                    PocketDroidsConstants.PLAYER_STEPS = 0 ;
                }
                else if (dbtask.IsCompleted)
                {
                    DataSnapshot snapshot = dbtask.Result;
                    PocketDroidsConstants.PLAYER_STEPS = (int)snapshot.Value;
                }
            });

        int Steps = PocketDroidsConstants.PLAYER_STEPS;
        double Distance = (Steps * (0.48));
        OnStep(Steps, Distance);
        //DontDestroyOnLoad(gameObject);
    }

    private void OnStep(int steps, double distance) {
        // Display the values
        StepText.text = steps.ToString();

        DatabaseReference dbref = FirebaseDatabase.DefaultInstance.RootReference;
        dbref. 
            Child("alumnos").
            Child(PocketDroidsConstants.USER_ID).
            Child("system").
            Child("pasosCaminados").
            SetValueAsync(steps);
        PocketDroidsConstants.PLAYER_STEPS = steps;
        DistanceText.text = (distance).ToString("F2") + " m";
        if((steps%100)==0){
            //Subject apear code
        }
    }

    private void OnDisable() {
        // Release the pedometer
        pedometer.Dispose();
        pedometer = null;
    }
 
}
