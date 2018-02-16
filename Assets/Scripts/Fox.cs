using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

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
			if (obj.GetComponent<Gravestone>()) {
				animatior.SetTrigger("JumpTrigger");
			} else {
				animatior.SetBool("IsAttacking", true);
				attacker.Attack(obj);
			}
		}
	}
}
