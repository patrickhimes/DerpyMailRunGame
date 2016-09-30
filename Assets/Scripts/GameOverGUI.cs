using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour
{
	
	private bool _gameOver = false;
	public GUISkin customSkin;
	public Texture2D icon;
	public string message;
	public string restartButton;
	public AudioClip soundBite;
	public AudioSource audioSource;
	
	void OnGUI () 
	{
		if(_gameOver)
		{
			GUI.skin = customSkin;
			if (GUI.Button (new Rect ((Screen.width/2)-75,275,150,75), restartButton))
				Application.LoadLevel(Application.loadedLevel);
		    
			GUI.Box (new Rect (5, Screen.height/3,Screen.width-10, 100), message);
			
		}
		
	}
	
	public void GameOver()
	{
		_gameOver = true;
		audioSource.PlayOneShot(soundBite);
	}
}

