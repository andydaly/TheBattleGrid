using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	// Mouse Look script
	// Author Andrew Daly
	// Must be attached to Player Object

	// Crosshair image
	public Texture2D crosshairImage;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumY = -30F;
	public float maximumY = 60F;
	
	
	PlayerMovement pm;
	float widthStop;
	float heightStop;
	float widthMove;
	float heightMove;
	float width;
	float height;

	float rotationY = 0F;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;

		pm = GetComponent<PlayerMovement>();


		widthStop = crosshairImage.width/5;
		heightStop = crosshairImage.height/5;
		widthMove = crosshairImage.width/2;
		heightMove = crosshairImage.height/2;
		width = crosshairImage.width/5;
		height = crosshairImage.width/5;
	}
	
	// Update is called once per frame
	void Update () {
	
		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
		transform.localEulerAngles = new Vector3(0, rotationX, -rotationY);

	}

	void OnGUI()
	{

//		Debug.Log(widthMove);



		if (pm.InMotion)
		{
			if (widthMove > width)
				width += 1.0f;
			if (heightMove > height)
				height += 1.0f;
		}
		else
		{
			if (widthStop < width)
				width -= 3.0f;
			if (heightStop < height)
				height -= 3.0f;
		}


		float xMin = (Screen.width / 2) - (width / 2);
		float yMin = (Screen.height / 2) - (height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, width, height), crosshairImage);
	}

}
