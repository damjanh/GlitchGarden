using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
	
	private StarDisplay starDisplay;

	public int cost = 100;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amount) {
		starDisplay.AddStars(amount);
	}
}
