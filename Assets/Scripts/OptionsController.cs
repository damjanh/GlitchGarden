using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;

	public Slider difficultySlider;

	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		// Find MusicManger, it will persist from 00_Splash Scene.
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		if (volumeSlider != null) {
			volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		}

		if (difficultySlider != null) {
			difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		}
	}

	void Update() {
		if (musicManager != null) {
			musicManager.SetVoulume(volumeSlider.value);
		}
	}

	public void SaveAndExit() {
		if (volumeSlider != null) {
			PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		}
		if (difficultySlider != null) {
			PlayerPrefsManager.SetDifficulty((int) difficultySlider.value);
		}
		levelManager.LoadLevel("01_Start");
	}

	public void SetDefaults() {
		volumeSlider.value = PlayerPrefsManager.DEFAULT_VOLUME;
		difficultySlider.value = PlayerPrefsManager.DEFAULT_DIFFICULTY;
	}
}
