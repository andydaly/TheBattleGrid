using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {


	// Shooting script
	// Author Andrew Daly
	// Must be attached to Player Object
	

	
	public AudioClip LaserSound;
	
	public GameObject BulletPrefab;
	public float bulletspeed = 200.0f;
	
	Transform myTransform;
	Transform SpawnPoint;
	
	bool Pressed;
	Transform CameraObj;
	
	
	void Start () {
		Pressed = false;
		myTransform = transform;
		SpawnPoint = myTransform.FindChild("Spawn");
		CameraObj = myTransform.FindChild("Camera");
	}
	
	void Update () {


		if (Input.GetButtonUp("Fire1"))
		{
			Pressed = false;
		}


		if ((Input.GetButton("Fire1")) && !Pressed)
		{

			GameObject Bullet = (GameObject)Instantiate(BulletPrefab, SpawnPoint.position, CameraObj.rotation); 
			Bullet.rigidbody.AddForce(-myTransform.right * bulletspeed, ForceMode.Impulse);
			// must have audiosource attached to object to play audio
			audio.Play();
			Pressed = true;
		}
	}
}
