using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/Moving")]

public class Moving : MonoBehaviour {
	
	private CharacterController _charController;

	[Range(1,10)]public float speed = 3;

	void Start () {
		_charController = gameObject.GetComponent<CharacterController> ();
	}

	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement *= Time.deltaTime;

		movement = transform.TransformDirection (movement);
		_charController.Move (movement);
	}
}
