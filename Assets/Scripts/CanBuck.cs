using UnityEngine;
using System.Collections;

public class CanBuck : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip sfx;

	void Start(){
		audioSource = this.gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D colliderObject) {
		Debug.Log ("Hit");
		if(colliderObject.gameObject.tag == "Hooves")
		{
			Debug.Log ("Bucked Cloud");
			audioSource.PlayOneShot (sfx);

		}
	}
}
