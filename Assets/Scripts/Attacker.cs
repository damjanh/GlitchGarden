﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private float currentSpeed;

	[Tooltip ("Average number of seconds between appearances.")]
	public float seenEverySeconds;

	private GameObject currentTarget;

	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
		rigidbody.isKinematic = true;

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTarget == null) {
			animator.SetBool("IsAttacking", false);
		}

		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	//Called from the animator 
	public void StrikeTarget(float damage) {
		if (currentTarget != null) {
			Health health = currentTarget.GetComponent<Health>();
			if (health != null) {
				health.Damage(damage);
			}
		}
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;		
	}
}
