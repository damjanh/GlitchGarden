using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	void Update() {
		foreach(GameObject attacker in attackerPrefabArray) {
			if(IsTimeToSpawn(attacker)) {
				Spawn(attacker);
			}
		}
	}

	void Spawn(GameObject attackerPrefab) {
		GameObject attacker = Instantiate(attackerPrefab) as GameObject;
		if (attacker != null) {
			attacker.transform.parent = transform;
			attacker.transform.position = transform.position;
		}
	}

	bool IsTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float meanSpanDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpanDelay;

		if (Time.deltaTime > meanSpanDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate!");
		}

		float threshold = spawnsPerSecond * Time.deltaTime;

		return Random.value < threshold / 5;
	}
}
