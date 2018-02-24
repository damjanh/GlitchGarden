using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour {

	private static Color unselectedColor = new Color(0.5f, 0.5f, 0.5f);

	private static Color disabledColor = Color.black;
	private static Color selectedColor = Color.white;

	public  GameObject spawns;

	private Defender spawnsDefender;

	private Button[] buttonArray;

	public static GameObject selectedDefender;

	private StarDisplay starDisplay;

	private SpriteRenderer thisSpriteRenderer;

	private enum State {DISABLED, AVAILABLE, SELECTED};

	private State state = State.DISABLED;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		buttonArray = GameObject.FindObjectsOfType<Button>();
		thisSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		thisSpriteRenderer.color = unselectedColor;

		spawnsDefender = spawns.GetComponent<Defender>();

		state = starDisplay.GetStars() >= spawnsDefender.cost ? State.AVAILABLE : State.DISABLED;
		switch(state) {
			case State.AVAILABLE:
				SetAvailable();
				break;
			case State.DISABLED:
				SetDisabled();
				break;
			case State.SELECTED:
			default:
				// Nothing
				break;
		}

		// Set cost
		Text text = GetComponentInChildren<Text>();
		text.text = spawnsDefender.cost.ToString(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.SELECTED && starDisplay.GetStars() < spawnsDefender.cost) {
			SetDisabled();
			selectedDefender = null;
		} else if (state == State.AVAILABLE && starDisplay.GetStars() < spawnsDefender.cost) {
			SetDisabled();
		} else if  (state == State.DISABLED && starDisplay.GetStars() >= spawnsDefender.cost) {
			SetAvailable();
		}
	}

	private void SetAvailable() {
		state = State.AVAILABLE;
		thisSpriteRenderer.color = unselectedColor;	
	}

	private void SetSelected() {
		state = State.SELECTED;
		thisSpriteRenderer.color = selectedColor;
	}

	private void SetDisabled() {
		state = State.DISABLED;
		thisSpriteRenderer.color = disabledColor;
	}

	private void SetAllUnselected() {
		foreach(Button thisButton in buttonArray) {
			thisButton.SetAvailable();
		}
		selectedDefender = null;
	}
	void OnMouseDown() {
		if (state == State.AVAILABLE && starDisplay.GetStars() >= spawnsDefender.cost) {
			SetAllUnselected();
			SetSelected();
			selectedDefender = spawns;
		}
	}
}
