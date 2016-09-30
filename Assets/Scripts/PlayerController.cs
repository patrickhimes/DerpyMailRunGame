using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = .5f;
	private bool facingRight = true;

	
	// Update is called once per frame
	void Update () {
		
		Vector3 playerPos = new Vector3( this.transform.position.x, this.transform.position.y, 0f);
		float moveX = 0;
		moveX = Input.GetAxis("Horizontal");
		float moveY = 0;
		moveY = Input.GetAxis("Vertical");
		//Debug.Log (moveh.ToString ());
		playerPos.x = Mathf.Clamp((playerPos.x+moveX), 0.5f, 9f);
		playerPos.y = Mathf.Clamp((playerPos.y+moveY), 0.5f, 9f);

		this.transform.position = playerPos;

		if(moveX > 0 && !facingRight){
			Flip ();
		}
		else if (moveX < 0 && facingRight){
			Flip ();
		}
	}
		   
	void Flip () {
		facingRight = !facingRight;
		Vector3 spriteScale = transform.localScale;
		spriteScale.x *= -1;
		transform.localScale = spriteScale;
	}
}
