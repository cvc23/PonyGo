using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

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

	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();

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
		levelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
	}

	public void updateXP() {
		xpText.text = GameManager.Instance.CurrentPlayer.Xp +
		              " / " + GameManager.Instance.CurrentPlayer.RequiredXp;
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
    }

    public void closeMenuOnClick(){
        menu.SetActive(false);
    }

    private void toggleMenu() {
		menu.SetActive(!menu.activeSelf);
	}
}
