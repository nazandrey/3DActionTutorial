using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health = 5.0f;

	public void Hurt(float damage){
		health -= damage;
	}
}
