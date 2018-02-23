using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public  GameObject projectile;

	public GameObject gun;

	private GameObject parent;

	void Start() {
		parent = GameObject.Find("Projectiles");
		if (parent == null) {
			parent = new GameObject("Projectiles");
		}
	}

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = parent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
