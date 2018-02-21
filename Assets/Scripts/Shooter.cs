using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile;

	public GameObject parent;

	public GameObject gun;

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = parent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
