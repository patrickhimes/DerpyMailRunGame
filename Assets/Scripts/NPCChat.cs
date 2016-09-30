using UnityEngine;
using System.Collections;

public class NPCChat : MonoBehaviour {
	protected Animator animator;
	private bool progressChat = false;
	public Dialogue[] dialogue;
	public GUISkin customSkin;
	private bool _hidden = true;
	private int lineIndex = 0;
	private bool canChat = false;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update (){
		Debug.Log ("Player entered chat area");
		//check for player interaction
		if (canChat) {
			if (Input.GetKeyDown (KeyCode.X) && !_hidden) {
				lineIndex++;
				if (dialogue.Length <= lineIndex) {
					_hidden = true;
					lineIndex = 0;
				}

			} else if (Input.GetKeyDown (KeyCode.X) && _hidden) {
				_hidden = false;
				Debug.Log ("Show dialog");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D colliderObject) {
		if(colliderObject.gameObject.tag == "Player")
		{
			canChat = true;
		}
	}

	void OnTriggerExit2D(Collider2D colliderObject) {
		_hidden = true;
		canChat = false;
		lineIndex = 0;
	}

	void OnGUI () 
	{
		if(! _hidden)
		{
			Debug.Log ("Player entered chat area");
			GUI.skin = customSkin;
			GUI.Label(new Rect(0,0,Screen.width,80), dialogue[lineIndex].line, "ChatBox");
			
		}
	}
}
