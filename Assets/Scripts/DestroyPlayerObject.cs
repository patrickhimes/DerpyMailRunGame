using UnityEngine;
using System.Collections;

public class DestroyPlayerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject player = GameObject.FindWithTag("Player");
		if (player) {
			GameObject.Destroy (player);
		}
	}

}
