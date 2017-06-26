using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class Shooting : MonoBehaviour {
	private Camera _camera;

	void Start () {
		_camera = gameObject.GetComponent<Camera> ();	

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {			
			Vector3 target = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			RaycastHit hit;
			Ray ray = _camera.ScreenPointToRay(target);
			if (Physics.Raycast (ray, out hit)) { 
				ReactiveTarget reactiveTarget = hit.transform.gameObject.GetComponent<ReactiveTarget>();
				if (reactiveTarget != null) {
					reactiveTarget.ReactToHit ();
				} else {
					StartCoroutine(CreateSphereAndDestroyAfter (hit.point));
				}
			}
		}
	}

	void OnGUI(){
		int size = 24;
		float x = (_camera.pixelWidth - size) / 2;
		float y = (_camera.pixelHeight - size) / 2;
		Rect position = new Rect (x, y, size, size);

		GUI.Label (position, "+");
	
	}

	private IEnumerator CreateSphereAndDestroyAfter(Vector3 spawnPoint){
		GameObject hitSphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		hitSphere.transform.position = spawnPoint;
		yield return new WaitForSeconds (2);
		Destroy (hitSphere);
	}
}
