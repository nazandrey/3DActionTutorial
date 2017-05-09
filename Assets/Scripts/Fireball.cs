using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float lifetime = 2.0f;
	public float speed = 3.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (0, 0, speed*Time.deltaTime);
	}
}
