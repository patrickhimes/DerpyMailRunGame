using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	public AudioClip[] levelMusic;

	AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource> ();
			//LoadLevelMusic (Application.loadedLevel);
		}
	}

	void OnLevelWasLoaded( int level){
		Debug.Log ("MusicPlayer: Loaded level " + level.ToString ());
		//LoadLevelMusic (level);
	}

	void LoadLevelMusic(int level){
		music.Stop ();
		
		music.clip = levelMusic [level];
		if (music.clip) {
			music.loop = true;
			music.Play ();
		}
	}
}
