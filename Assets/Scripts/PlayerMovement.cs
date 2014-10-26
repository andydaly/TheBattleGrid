using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	// Player Movement script
	// Author Andrew Daly
	// Must be attached to Player Object


	public float MoveSpeed = 6.0F;
	CharacterController cc;
	float Acceleration = 0.0f;
	public bool InMotion;


	
	
	void Start () {
		cc = GetComponent<CharacterController>();
		InMotion = false;
	}
	
	// Update is called once per frame
	void Update () {
	


		float VerticalSpeed = Input.GetAxis("Vertical") * MoveSpeed;
		float HorizontalSpeed = Input.GetAxis ("Horizontal") * MoveSpeed;

		if ((Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0))
		{
			InMotion = true;
		}
		else
		{
			InMotion = false;
		}

		Vector3 Speed = new Vector3(-VerticalSpeed,  0,HorizontalSpeed);

		Speed = transform.rotation * Speed;
		cc.SimpleMove(Speed);

	}


}
