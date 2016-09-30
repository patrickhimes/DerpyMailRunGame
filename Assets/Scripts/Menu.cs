using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string gameTitle;
	public string startButton;
	public GUISkin customSkin;
	private bool _hidden = false;
	
	void OnGUI () 
	{
		if(! _hidden)
		{
			GUI.skin = customSkin;
			GUI.Label(new Rect(Screen.width/2-250,Screen.height/2-80,500,80), gameTitle, "title");
			if(GUI.Button(new Rect(Screen.width/2-60,Screen.height-(Screen.height/3),120,50), startButton))
				Application.LoadLevel(1);	

		}
	}
	
	public void Hide()
	{
		_hidden = true;
	}
}
