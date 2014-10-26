using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {


	// Player Health script
	// Author Andrew Daly
	// Must be attached to Player Object
	

	public float Health = 100f;            
	public float ResetTime = 2f;

	public Texture2D bgImage; 
	public Texture2D fgImage; 

	public GameObject Explosion;

	public Camera MainCamera;
	public Camera DeathCamera;

	private float Timer = 0.0f; 
	private bool playerDead;




	
	private float MaxHealth = 100f;
	private float healthBarLength;

	// Use this for initialization
	void Start () {

		healthBarLength = (Screen.width /2);  
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Health <= 0f)
		{

			PlayerDead();
			LevelReset();
		}
		AdjustHealth(0);

	}


	void OnGUI () {
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect ((Screen.width /2)-(Screen.width /4),5, (Screen.width /2)+(Screen.width /4),20));
		
		// Draw the background image
		GUI.DrawTexture (new Rect (0,0, healthBarLength,20), bgImage);
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, Health / MaxHealth * healthBarLength, 20));
		
		// Draw the foreground image
		GUI.DrawTexture (new Rect (0,0,healthBarLength,20), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}


	void LevelReset ()
	{
		// Increment the timer.
		Timer += Time.deltaTime;
		
		//If the timer is greater than or equal to the time before the level resets...
		if(Timer >= ResetTime)
		{
			Application.LoadLevel(Application.loadedLevel);
		}

	}


	void PlayerDead ()
	{
		GetComponent<MouseLook>().enabled = false;
		GetComponent<PlayerMovement>().enabled = false;
		GetComponent<Shooting>().enabled = false;
		GetComponent<UpdatePause>().enabled = false;

		MainCamera.enabled = false;
		DeathCamera.enabled = true;
		Instantiate(Explosion, transform.position, transform.rotation);
	}


	public void AdjustHealth(float Amount){
		
		Health += Amount;
		

		if(Health > MaxHealth)
			Health = MaxHealth;

	}


	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "ELaser")
		{
			AdjustHealth(-10);
			
		}

	}



}
