using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;

public class UIManager : MonoBehaviour {

	[SerializeField] private Text xpText;
	[SerializeField] private Text levelText;
	[SerializeField] private GameObject menu;
    [SerializeField] private GameObject alert;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private Button training;
    [SerializeField] private Button tutorial;
    [SerializeField] private Button logout;
    [SerializeField] private Button closeMenu;
    [SerializeField] private Button closeAlert;
    [SerializeField] private AudioClip menuBtnSound;
    [SerializeField] private Text Name;

    private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
        Name.text = PocketDroidsConstants.USER_NICKNAME;
		Assert.IsNotNull(audioSource);
		Assert.IsNotNull(xpText);
		Assert.IsNotNull(levelText);
		Assert.IsNotNull(menu);
		Assert.IsNotNull(menuBtnSound);
	}

    public void CloseAlert(){
        alert.SetActive(false);
    }

	private void Update() {
		updateLevel();
		updateXP();
	}

	public void updateLevel() {
		levelText.text = PocketDroidsConstants.APROVED_SUBJECTS.Count + "";
	}

	public void updateXP() {
		xpText.text = PocketDroidsConstants.CAPTUREDPRO_SUBJECTS.Count +
		              " / " + PocketDroidsConstants.GOAL_SUBJECTS;
	}

	public void MenuBtnClicked() 
    {
		audioSource.PlayOneShot(menuBtnSound);
        //		toggleMenu();
        menu.SetActive(true);
    }

    public void TrainingButtonOnClick()
    {
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
        Instance.GoToScene(PocketDroidsConstants.SCENE_TRAINING, objects);
    }


    public void TutorialButtonOnClick()
    {
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
        Instance.GoToScene(PocketDroidsConstants.SCENE_TUTORIAL, objects);
    }

    public void logoutButtonOnClick()
    {
        //TODO
        //  y la escena de Login ? 
        FirebaseAuth.DefaultInstance.SignOut();
          
        List<GameObject> objects = new List<GameObject>();
        SceneTransitionManager.
                              Instance.GoToScene(PocketDroidsConstants.SCENE_LOGIN, objects);

    }

    public void closeMenuOnClick(){
        menu.SetActive(false);
    }

    private void toggleMenu() {
		menu.SetActive(!menu.activeSelf);
	}
}
