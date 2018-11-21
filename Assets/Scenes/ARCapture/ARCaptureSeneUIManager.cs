using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ARCaptureSeneUIManager : MonoBehaviour {

    [SerializeField] private ARCaptureSceneManager manager;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private Text orbCountText;

    private void Awake()
    {
        Assert.IsNotNull(manager);
        Assert.IsNotNull(successScreen);
        Assert.IsNotNull(failScreen);
        Assert.IsNotNull(gameScreen);
    }


    void Update()
    {
        switch (manager.Status)
        {
            case ARCaptureSceneStatus.InProgress:
                HandleInProgress();
                break;
            case ARCaptureSceneStatus.Successful:
                HandleSuccess();
                break;
            case ARCaptureSceneStatus.Failed:
                HandleFailure();
                break;
            default:
                break;
        }
    }

    private void HandleInProgress()
    {
        UpdateVisibleScreen();
        orbCountText.text = manager.CurrentThrowAttempts.ToString();
    }

    private void HandleSuccess()
    {
        UpdateVisibleScreen();
    }

    private void HandleFailure()
    {
        UpdateVisibleScreen();
    }

    private void UpdateVisibleScreen()
    {
        successScreen.SetActive(manager.Status == ARCaptureSceneStatus.Successful);
        failScreen.SetActive(manager.Status == ARCaptureSceneStatus.Failed);
        gameScreen.SetActive(manager.Status == ARCaptureSceneStatus.InProgress);
    }
}
