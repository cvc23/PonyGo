using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;
using UnityEngine.Assertions;

public class StepCounter : MonoBehaviour {

    [SerializeField] private Text StepText;
    [SerializeField] private Text DistanceText;
    private Pedometer pedometer;

    private void Start() {
        // Create a new pedometer
        pedometer = new Pedometer(OnStep);
        // Reset UI
        //Charge number of steps from firebase
        int Steps = 0;
        double Distance = (Steps * (0.58));
        OnStep(Steps, Distance);
        DontDestroyOnLoad(gameObject);
    }

    private void OnStep(int steps, double distance) {
        // Display the values // Distance in feet
        StepText.text = steps.ToString();
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
