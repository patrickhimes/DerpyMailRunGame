using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		MusicManager musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.SetVolume (PlayerPrefsManager.GetMasterVolume ());
		} else {
			Debug.LogError("musicManager not found!");
		}

	}

}
