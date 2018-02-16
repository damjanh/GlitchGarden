using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private float currentSpeed;

	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
		rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D() {
		Debug.Log(name + " trigger enter.");
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	//Called from the animator 
	public void StrikeTarget(float damage) {
		Debug.Log(name + " strike on the target for " + damage + " damage.");
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}
