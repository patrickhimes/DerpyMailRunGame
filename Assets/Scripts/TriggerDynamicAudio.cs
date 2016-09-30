using UnityEngine;
using System.Collections;

public class TriggerDynamicAudio : MonoBehaviour {
	public string triggerEnterMusicZone;
	public string triggerExitMusicZone;

	public DynamicAudioController dAC;
	
	public void OnTriggerEnter2D( Collider2D col){

		dAC.SetMusicZone (triggerEnterMusicZone);
		Debug.Log ("play "+ triggerEnterMusicZone);
	}
	
	public void OnTriggerExit2D( Collider2D col){
		
		dAC.SetMusicZone (triggerExitMusicZone);
		Debug.Log ("play "+ triggerExitMusicZone);
	}

}
