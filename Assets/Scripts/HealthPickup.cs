using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	
	// Health Pickup script
	// Author Andrew Daly
	// Must be attached to Health Pickup perfab
	
	public float rotationsPerMinute = 5.0f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0,6.0f*rotationsPerMinute*Time.deltaTime,0);
	}


	void OnTriggerEnter(Collider collider) {


		if (collider.gameObject.tag == "Player")
		{
			collider.gameObject.transform.SendMessage("AdjustHealth", 80);
			Destroy(this.gameObject);
		}
	}

}