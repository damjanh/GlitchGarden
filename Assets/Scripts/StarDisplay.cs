using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;

	private int stars = 100;

	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		UpdateUI();
	}

	public void AddStars (int amount) {
		stars += amount;
		UpdateUI();
	}

	public Status UseStars(int amount) {
		if (stars >= amount) {
			stars -= amount;
			UpdateUI();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	void UpdateUI() {
		starText.text = stars.ToString();
	}

	public int GetStars() {
		return stars;
	}
}
