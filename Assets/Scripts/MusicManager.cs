using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusic;
	
	AudioSource audioSource;

	void Start(){
		GameObject.DontDestroyOnLoad(gameObject);

		audioSource = this.gameObject.GetComponent<AudioSource> ();
		LoadLevelMusic (Application.loadedLevel);
	}

	void OnLevelWasLoaded( int level){
		Debug.Log ("MusicPlayer: Loaded level " + level.ToString ());
		LoadLevelMusic (level);
	}
	
	void LoadLevelMusic(int level){
		AudioClip loadClip = levelMusic [level];

		if (loadClip && loadClip != audioSource.clip) {
			audioSource.Stop ();
			audioSource.clip = loadClip;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void SetVolume( float volume){
		audioSource.volume = volume;
	}
}
