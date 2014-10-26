using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Bullet Script
	// Author Andrew Daly
	// Attached to bullet Prefab

	void OnCollisionEnter(Collision collision) {
	
		Destroy(this.gameObject);
	}

}
