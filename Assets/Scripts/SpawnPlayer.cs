using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	public int sceneIndex = 0;
	protected SpriteRenderer spriteRenderer;
	public GameObject playerPrefab;
	
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		//turn off or remove spirte renderer
		spriteRenderer.enabled = false;
	}

	void Awake () {
		CreatePlayerObject();
	}
	
	void OnLevelWasLoaded(int thisLevel)
	{
		CreatePlayerObject();
	}

	void CreatePlayerObject(){
		//look for existing player game object
		GameObject player = GameObject.FindWithTag("Player");
		
		//create player game object if not found and prefab is defined
		if(!player && playerPrefab)
		{
			//spawn player from prefab
			player = (GameObject) Instantiate(playerPrefab, transform.position, transform.rotation);
		}
	}

}
