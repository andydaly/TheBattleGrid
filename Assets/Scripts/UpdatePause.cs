using UnityEngine;
using System.Collections;

public class UpdatePause : MonoBehaviour {

	// Update Pause script
	// Author Andrew Daly
	// Must be attached to Player Object
	

	public Camera MainCamera;
	public Camera PauseCamera;
	PauseMenu menuScreen;
	


	// Use this for initialization
	void Start () {
		MainCamera.enabled=true;
		PauseCamera.enabled=false;
		menuScreen = GetComponent<PauseMenu>();
		menuScreen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			Time.timeScale = 0;
			MainCamera.enabled = false;
			PauseCamera.enabled = true;
			GetComponent<MouseLook>().enabled = false;
			GetComponent<PlayerMovement>().enabled = false;
			GetComponent<Shooting>().enabled = false;

			menuScreen.enabled = true;
		}

		if (!menuScreen.IsActive)
		{
			Time.timeScale = 1.0f;
			MainCamera.enabled = true;
			PauseCamera.enabled = false;
			GetComponent<MouseLook>().enabled = true;
			GetComponent<PlayerMovement>().enabled = true;
			GetComponent<Shooting>().enabled = true;
			menuScreen.IsActive = true;

			menuScreen.enabled = false;
		}

	}
}
