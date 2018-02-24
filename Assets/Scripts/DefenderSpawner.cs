using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera mainCamera;

	private GameObject parent;

	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		parent = GameObject.Find("Defenders");
		if (parent == null) {
			parent = new GameObject("Defenders");
			parent.transform.position.Set(0f, 0f, 0f);
		}
	}

	void OnMouseDown() {
		if (Button.selectedDefender != null) {

			int cost = Button.selectedDefender.GetComponent<Defender>().cost;

			if (starDisplay.UseStars(cost) == StarDisplay.Status.SUCCESS) {
				SpawnDefender(Button.selectedDefender);
			} else {
				Debug.Log("Insufficient funds!");
			}
		}
	}

	private void SpawnDefender(GameObject selectedDefender) {
		GameObject defender =Instantiate(Button.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
		defender.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
	}

	Vector2 SnapToGrid(Vector2 worldPosition) {
		return new Vector2(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
	}
}
