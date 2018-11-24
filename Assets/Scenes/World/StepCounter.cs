using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;
using UnityEngine.Assertions;
using System;

public class StepCounter : MonoBehaviour {

    [SerializeField] private Text StepText;
    [SerializeField] private Text DistanceText;
    private Pedometer pedometer;

    private void Start() {
        // Create a new pedometer
        pedometer = new Pedometer(OnStep);
        // Reset UI
        //Charge number of steps from firebase
        int Steps = PocketDroidsConstants.PLAYER_STEPS;
        double Distance = (Steps * (0.48));
        OnStep(Steps, Distance);
        DontDestroyOnLoad(gameObject);
    }

    private void OnStep(int steps, double distance) {
        // Display the values
        StepText.text = steps.ToString();
        PocketDroidsConstants.PLAYER_STEPS = steps;
        DistanceText.text = (distance).ToString("F2") + " m";
        if((steps%100)==0){
            //Subject apear code
        }
    }

    private void OnDisable() {
        // Release the pedometer
        //pedometer.Dispose();
        //pedometer = null;
    }
 
}
