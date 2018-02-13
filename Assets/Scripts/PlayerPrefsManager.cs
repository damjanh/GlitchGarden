using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	private const string MASTER_VOLUME_KEY = "master_volume";
	private const string DIFFICULTY_KEY = "difficulty";
	private const string LEVEL_KEY = "level_unlocked_";

	// Defaults
	public const float DEFAULT_VOLUME = 0.8f;
	public const int DEFAULT_DIFFICULTY = 2;

	public static void SetMasterVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range.");
		}
	}

	public static float GetMasterVolume() {
		if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
			return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
		} else {
			return DEFAULT_VOLUME;
		}
	}

	public static void UnlockLevel(int level) {
		if (level <= SceneManager.sceneCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Cannot unlock level that is not in build order.");
		}
	}

	public static bool IsLevelUnlocked(int level) {
		if (level <= SceneManager.sceneCount - 1) {
			return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
		} else {
			Debug.LogError("Cannot unlock level that is not in build order.");
			return false;
		}
	}

	public static void SetDifficulty(int difficulty) {
		if (difficulty >= 0 && difficulty <= 3) {
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range.");
		}
	}

	public static int GetDifficulty() {
		if (PlayerPrefs.HasKey(DIFFICULTY_KEY)) {
			return PlayerPrefs.GetInt(DIFFICULTY_KEY);
		} else {
			return DEFAULT_DIFFICULTY;
		}
	}
}
