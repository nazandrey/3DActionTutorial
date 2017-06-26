using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

	public float speed = 1f;
	public float scanningRange = 0.5f;
	[SerializeField] private GameObject _fireballPrefab;
	private bool _alive;
	private bool _reloading;

	void Start () {
		_alive = true;
	}
	
	void Update () {
		if (_alive) {
			RaycastHit hit;
			if (Physics.SphereCast (transform.position, scanningRange, transform.forward, out hit, 1f)) {
				bool hitPlayer = hit.transform.name == "Player";
				if (hitPlayer && !_reloading) {
					GameObject fireball = Instantiate (_fireballPrefab);
					fireball.transform.position = transform.TransformPoint(Vector3.forward*1.5f);
					fireball.transform.rotation = transform.rotation;
					StartCoroutine(Reload ());
					_reloading = true;
				} else if (!hitPlayer){
					float angle = Random.Range (-110, 110);
					transform.Rotate (new Vector3 (0, angle, 0));
				}
			} else {
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
			}
		}
	}

	public void setAlive(bool alive){
		_alive = alive;
	}

	private IEnumerator Reload (){
		yield return new WaitForSeconds (2.0f);
		_reloading = false;
	}
}
