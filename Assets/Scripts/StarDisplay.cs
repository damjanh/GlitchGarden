using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;

	private int stars = 0;

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		UpdateUI();
	}

	public void AddStars (int amount) {
		stars += amount;
		UpdateUI();
	}

	public void UseStars(int amount) {
		stars -= amount;
		UpdateUI();
	}

	void UpdateUI() {
		starText.text = stars.ToString();
	}
}
