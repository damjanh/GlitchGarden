using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	private static Color unselectedColor = new Color(0.5f, 0.5f, 0.5f);
	private static Color selectedColor = Color.white;

	public  GameObject spawns;

	private Button[] buttonArray;

	public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		GetComponentInChildren<SpriteRenderer>().color = unselectedColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		SetAllUnselected();
		GetComponentInChildren<SpriteRenderer>().color = selectedColor;
		selectedDefender = spawns;
	}

	private void SetAllUnselected() {
		foreach(Button thisButton in buttonArray) {
			thisButton.GetComponentInChildren<SpriteRenderer>().color = unselectedColor;
		}
	}
}
