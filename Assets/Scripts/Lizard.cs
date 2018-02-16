using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Animator animatior;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animatior = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject;
		if (obj.GetComponent<Defender>()) {
			animatior.SetBool("IsAttacking", true);
			attacker.Attack(obj);
		}
	}
}
