using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public GameObject playerPrefab;
	private float playerPreviousPosition;
	private Quaternion playerPreviousRotation;
	private int previousSceneIndex = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void SavePlayerLocation ( float relativePos) {
		playerPreviousPosition = relativePos;
	}

	void OnLevelWasLoaded(int level) {

		//find player spawn point
		ExitScene[] entryPoints = FindObjectsOfType(typeof(ExitScene)) as ExitScene[];
		foreach ( ExitScene entryPoint in entryPoints){
			if(entryPoint.GetSceneIndex() == previousSceneIndex) {
				GameObject gate = GameObject.Find(entryPoint.gameObject.name);
				//place player at this enterance
				Vector3 positionAtGate = new Vector3(gate.transform.position.x, gate.transform.position.y * playerPreviousPosition, 0);
				player = GameObject.FindGameObjectWithTag("Player");
				player.transform.position = positionAtGate; 
				//player = (GameObject) Instantiate(playerPrefab, positionAtGate, playerPreviousRotation);
			}
		}
	}

	void LoadLevel (int level) {
		//save playerstate
		playerPreviousRotation = player.transform.rotation;

		previousSceneIndex = Application.loadedLevel;
		Application.LoadLevel(level);
	}

}
