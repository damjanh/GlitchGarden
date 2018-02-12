using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip[] levelMusicArray;

	void Awake() {
		// Persist this game object
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicArray[level];
		// If we have an AudioClip associated with a level index play it.
		if (thisLevelMusic != null) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
