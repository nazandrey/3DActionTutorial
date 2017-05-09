using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class Shooting : MonoBehaviour {
	private Camera _camera;

	// Use this for initialization
	void Start () {
		_camera = gameObject.GetComponent<Camera> ();	

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown(0)) {			
			Vector3 target = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

			RaycastHit hit;

			/*float x = Screen.width / 2;
			float y = Screen.height / 2;

			Ray ray = _camera.ScreenPointToRay(new Vector3(x, y, 0));*/
			Ray ray = _camera.ScreenPointToRay(target);
			if (Physics.Raycast (ray, out hit)) { 
				ReactiveTarget reactiveTarget = hit.transform.gameObject.GetComponent<ReactiveTarget>();
				if (reactiveTarget != null) {
					reactiveTarget.ReactToHit ();
				} else {
					StartCoroutine(CreateSphereAndDestroyAfter (hit.point));
				}
			//if (Physics.Raycast (_camera.transform.position, Input.mousePosition, out hit)) { 


				//Debug.DrawLine(_camera.transform.position, Input.mousePosition, Color.cyan, 20);
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

	/*
	 var crosshairTexture : Texture2D;
	 var position : Rect;
	 static var OriginalOn = true;
	 
	 function Start()
	 {
	     position = Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - 
	         crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
	 }
	 
	 function OnGUI()
	 {
	     if(OriginalOn == true)
	     {
	         GUI.DrawTexture(position, crosshairTexture);
	     }
	 }
	*/
}
