using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel = 3f;

	void Start()
	{
		Invoke("LoadNextLevel", autoLoadNextLevel);
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
