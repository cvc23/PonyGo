using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Droid : MonoBehaviour {

    //used
	[SerializeField] private AudioClip crySound;
    [SerializeField] private string subject;
    [SerializeField] private int semester;
    [SerializeField] private int credits;
    [SerializeField] private string requiredSubject;
    [SerializeField] private string id;

	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
		Assert.IsNotNull(audioSource);
		Assert.IsNotNull(crySound);
	}

    //Not used
	private void Start() {
//		DontDestroyOnLoad(this);
	}

    public string Subject
    {
        get { return subject; }
    }

    public int Credits
    {
        get { return credits; }
    }

    public int Semester
    {
        get { return semester; }
    }

    public string RequiredSubject
    {
        get { return requiredSubject; }
    }

    public string Id
    {
        get { return id; }
    }

    private void OnMouseDown() {
		PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
		audioSource.PlayOneShot(crySound);
		foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers) {
			if (pocketDroidsSceneManager.gameObject.activeSelf) {
				pocketDroidsSceneManager.droidTapped(this.gameObject);
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
		foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers) {
			if (pocketDroidsSceneManager.gameObject.activeSelf) {
				pocketDroidsSceneManager.droidCollision(this.gameObject, other);
			}
		}
	}
}
