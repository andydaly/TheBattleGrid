using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

	// Pause Menu script
	// Author Andrew Daly
	// Must be attached to Player Object

	GUISkin newSkin;
	public Texture2D logoTexture;
	public bool IsActive = true;

	public void thePauseMenu()
	{
		Screen.showCursor = true;
		Screen.lockCursor = false;
		
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));

		//the menu background box
		GUI.Box(new Rect(0, 0, 300, 250), "");
		
		//logo picture
		GUI.Label(new Rect(15, 10, 300, 68), logoTexture);
	
		
		//game resume button
		if(GUI.Button(new Rect(55, 100, 180, 40), "Resume"))
		{
			Screen.showCursor = false;
			Screen.lockCursor = true;
			IsActive = false;
		}
		
		// game restart buttton
		if(GUI.Button(new Rect(55, 150, 180, 40), "Restart"))
		{
			Time.timeScale = 1.0f;
			Application.LoadLevel(Application.loadedLevel);
		}
		
		// quit button
		if(GUI.Button(new Rect(55, 200, 180, 40), "Quit"))
		{
			Application.Quit();	
		}
		
		GUI.EndGroup();
			
	}
	
	
	void OnGUI ()
	{
		GUI.skin = newSkin;		
		thePauseMenu();
		
	}
}