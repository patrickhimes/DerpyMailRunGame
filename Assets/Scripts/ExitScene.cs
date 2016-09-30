using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitScene : MonoBehaviour {
	public bool loadPreviousScene = false;
	private int sceneIndex;

	void Awake(){
		
		if (loadPreviousScene) {
			sceneIndex = SceneManager.GetActiveScene ().buildIndex - 1;
		} else {
			sceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		}
	}

	void OnTriggerStay2D(Collider2D colliderObject) {

		if(colliderObject.gameObject.tag == "Player" && Input.GetButtonDown( "Interact" ))
		{
			SceneManager.LoadScene(sceneIndex);
		}
	}

	public int GetSceneIndex(){
		return sceneIndex;
	}

}
