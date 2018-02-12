using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel = 0f;

	void Start()
	{
		if (autoLoadNextLevel > 0) {
			Invoke("LoadNextLevel", autoLoadNextLevel);
		}
	}

	public void LoadLevel (string levelName)
	{
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}

	public void Quit ()
	{
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
