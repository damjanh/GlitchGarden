using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		GameObject obj = collider.gameObject;
		// Animated under attack when triggering with any Attacker, but not with the Fox.
		if (obj.GetComponent<Attacker>() && obj.GetComponent<Fox>() == null) {
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
