using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFICULTY_KEY = "dificulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVoluem(float volume) {
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range.");
		}
	}

	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
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

	public static void SetDificulty(float dificulty) {
		if (dificulty >= 0f && dificulty <= 1f) {
			PlayerPrefs.SetFloat(DIFICULTY_KEY, dificulty);
		} else {
			Debug.LogError("Dificulty out of range.");
		}
	}

	public static float GetDificulty() {
		return PlayerPrefs.GetFloat(DIFICULTY_KEY);
	}
}
