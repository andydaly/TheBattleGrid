using UnityEngine;
using System.Collections;

public class EnemyView : MonoBehaviour {

	// Enemy View Script
	// Author Andrew Daly
	// must be attached to enemy models child object View

	public bool EnemySighted;
	public int RotationSpeed = 10;

	private GameObject player;
	private SphereCollider col;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		col = GetComponent<SphereCollider>();
		EnemySighted = false;
	}
	

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player)
		{
			EnemySighted = true;
			// Enemy turns to face player
			transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, Quaternion.LookRotation(player.transform.position - transform.parent.position), RotationSpeed * Time.deltaTime);

		}


	}

	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == player)
			EnemySighted = false;
	}


}
