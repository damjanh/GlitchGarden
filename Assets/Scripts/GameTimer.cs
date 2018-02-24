using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private Slider slider;

	public float levelTimeSeconds = 60;

	private AudioSource audioSource;

	private LevelManager levelManager;

	private GameObject winText;

	private bool isEnd = false;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		winText = GameObject.Find("WinText");
		winText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelTimeSeconds;
		if (!isEnd && Time.timeSinceLevelLoad >= levelTimeSeconds) {
			isEnd = true;
			audioSource.volume = PlayerPrefsManager.GetMasterVolume();
			audioSource.Play();
			winText.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
		}
	}

	private void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
