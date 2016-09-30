using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DynamicAudioController : MonoBehaviour {

	public float bpm = 128;   // beats per minute
	public int bpb = 4;     // beats per bar
	public int srt = 44100; // sample rate
	public MusicZone next;
	public int start = 0;
	public int length;
	public int end;

	private List<MusicZone> musicZones = new List<MusicZone>();
	private float bar_length = 0;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		DefineMusicZones ();

		bar_length = (float)(( 60 / ( bpm / bpb ) ) * srt);
		
		Debug.Log ("bar_length: " +  ((60 / ( bpm / bpb ) ) * srt));
		CalculateLengthOfZones ();

		SetMusicZone ("relaxed");
		audioSource.Play ();
		Debug.Log ("total samples: " + audioSource.clip.samples);
	}
	
	// Update is called once per frame
	void Update () {
		float end = start + length;
		Debug.Log (end);
		if (audioSource.timeSamples >= end) {

			if (next != null) {
				// play next music zone
				start = next.start;
				length = next.length;
				next = null;
			}

			audioSource.timeSamples = start;
			audioSource.Play();
		}

	}

	public void SetMusicZone( string zoneName){
		foreach(MusicZone musicZone in musicZones)
		{
			if(musicZone.name == zoneName){
				//match found
				next = musicZone;
				break;
			}
		}

	}

	private void DefineMusicZones(){
		// use this until you figure out how to expose data to Unity's inspector 

		MusicZone zone01 = new MusicZone ("relaxed",2,0);
		musicZones.Add (zone01);
		Debug.Log (musicZones.Count);

		MusicZone zone02 = new MusicZone ("hunted",2,0);
		
		musicZones.Add (zone02);
		Debug.Log (musicZones.Count);


	}

	private void CalculateLengthOfZones(){
		int s = 0;

		foreach(MusicZone musicZone in musicZones)
		{
			musicZone.start  = s;
			musicZone.length = musicZone.size * (int)bar_length;
			Debug.Log(musicZone.name + " starts at " + musicZone.start + " and ends at " + (musicZone.start + musicZone.length));
			s += musicZone.length;
		}

	}
}
