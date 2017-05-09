using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Control Scripts/MouseLook")]

public class MouseLook : MonoBehaviour {
	[Range(1,10)] public float sensitivity = 3;

	[Range(-60,-30)]public float minVert = -45;
	[Range(30,60)]public float maxVert = 45;

	private float _rotationX = 0;
	private float _rotationY = 0;

	void Update () {
		_rotationX -= Input.GetAxis ("Mouse Y") * sensitivity;
		_rotationY += Input.GetAxis ("Mouse X") * sensitivity;

		_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);

		transform.localEulerAngles = new Vector3 (_rotationX, _rotationY, 0);
	}
}
