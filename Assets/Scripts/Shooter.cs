using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public  GameObject projectile;

	public GameObject gun;

	private GameObject parent;

	private Animator animator;

	private Spawner laneSpawner;

	void Start() {
		animator = GetComponent<Animator>();

		parent = GameObject.Find("Projectiles");
		if (parent == null) {
			parent = new GameObject("Projectiles");
		}

		laneSpawner = FindCorrectLaneSpawner();
	}

	void Update() {
		animator.SetBool("IsAttacking", IsAttackerAheadInLane());
	}

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = parent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	bool IsAttackerAheadInLane() {
		if (laneSpawner.transform.childCount > 0) {
			foreach (Transform child in laneSpawner.transform) {
				if (child.transform.position.x > transform.position.x) {
					return true;
				}
			}
		} 
		return false;
	}

	private Spawner FindCorrectLaneSpawner() {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
		foreach(Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				return spawner;
			}
		}
		Debug.LogError(name + ": can't find spawner in lane!");
		return null;
	}
}
