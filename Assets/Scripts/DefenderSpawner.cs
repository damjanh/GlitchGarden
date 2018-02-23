using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera mainCamera;

	private GameObject parent;

	void Start() {
		parent = GameObject.Find("Defenders");
		if (parent == null) {
			parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		if (Button.selectedDefender != null) {
			GameObject defender = Instantiate(Button.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
			defender.transform.parent = parent.transform;
		}
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
	}

	Vector2 SnapToGrid(Vector2 worldPosition) {
		return new Vector2(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
	}
}
