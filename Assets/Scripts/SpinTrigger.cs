using UnityEngine;
using System.Collections;

public class SpinTrigger : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D colliderObject) {

		if(colliderObject.gameObject.tag == "Player")
		{
			Animator animator = colliderObject.gameObject.GetComponent<Animator>();
			animator.SetTrigger ("Spinout");
		}
	}
}
