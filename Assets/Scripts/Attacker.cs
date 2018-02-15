using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range (0f, 1.5f)]
	public float currentSpeed;

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

	public void StrikeTarget(float damage) {
		Debug.Log(name + " strike on the target for " + damage + " damage.");
	}
}
