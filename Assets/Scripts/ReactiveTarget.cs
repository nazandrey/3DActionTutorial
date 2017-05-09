using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
	public void ReactToHit(){
		StartCoroutine (Die());
	}

	private IEnumerator Die(){		
		transform.Rotate (75,0,0);

		WanderingAI wanderingAI = gameObject.GetComponent<WanderingAI> ();
		if (wanderingAI != null) {
			wanderingAI.setAlive (false);
		}
		yield return new WaitForSeconds(1.5f);

		Destroy (gameObject);
	}
}
