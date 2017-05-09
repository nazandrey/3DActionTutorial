using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/Gravity")]

public class Gravity : MonoBehaviour {
	[Range(-20,0)]public float gravity = -9.8f;

	private CharacterController _charController;


	void Start () {
		_charController = gameObject.GetComponent<CharacterController> ();
	}

	void Update () {
		if (transform.position.y > 0) {
			Vector3 gravityVector = new Vector3(0, gravity * Time.deltaTime, 0);
			_charController.Move(gravityVector);
		}
	}
}
