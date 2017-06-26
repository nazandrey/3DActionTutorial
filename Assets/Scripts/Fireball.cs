using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float lifetime = 2.0f;
	public float speed = 3.0f;

	void Start () {
		Destroy (gameObject, lifetime);
	}
	
	void Update () {
		gameObject.transform.Translate (0, 0, speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.name == "Player") {
			Debug.Log ("Player hit");
		}
		Destroy (gameObject);
	}
}
