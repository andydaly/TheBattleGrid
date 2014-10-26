using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	// Enemy Health Script
	// Author Andrew Daly
	// must be attached to all enemys
	

	public float Health = 100f;   
	//Explosion Animation
	public GameObject Explosion;

	
	void Update () {
		if(Health <= 0f)
		{
			Death();
		}
	}


	void Death ()
	{
		Instantiate(Explosion, transform.position, transform.rotation);
		Destroy (this.gameObject);
		
	}

	public void TakeDamage (float Amount)
	{
		Health -= Amount;
	}



}
