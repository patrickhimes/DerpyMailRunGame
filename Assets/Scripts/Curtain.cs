using UnityEngine;
using System.Collections;

public class Curtain : MonoBehaviour {

	public string curtainText;
	public float duration = 5;
	public GUISkin customSkin;
	private bool _hidden = false;
	private float startTime;
	protected SpriteRenderer spriteRenderer;
	private GameObject _player;
	void OnGUI () 
	{
		if(! _hidden)
		{
			GUI.skin = customSkin;
			GUI.Label(new Rect(Screen.width/2-250,Screen.height/2-80,500,80), curtainText, "Title");

		}
	}
	
	public void Hide()
	{
		_hidden = true;
		//turn off or remove spirte renderer
		spriteRenderer.enabled = false;

		//ensure player controls are enabled
		_player.SendMessage("EnableControls");
		GameObject.Destroy (this.gameObject);
	}

	void Start () {
		_hidden = false;
		startTime = Time.time;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = true;
		_player = GameObject.FindWithTag("Player");
		_player.SendMessage("DisableControls");
	}

	void FixedUpdate () {
		if( (Time.time - startTime) > duration )
			Hide();
	}


}
