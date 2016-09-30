using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	public Fading fade;
	public string loadLevelName;

	void Start(){
		fade = GameObject.FindObjectOfType<Fading> ();

		if (autoLoadNextLevelAfter > 0) {
			Invoke ("LoadNextLevelWithFade", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}

	public void LoadLevelWithFade(string levelName){
		loadLevelName = levelName;

		if (fade) {
			Invoke ("LoadLevelWithFadeInvoke", fade.BeginFade (1));
		} else {
			Debug.Log ("fade component not found on gameObject!");
			//LoadLevel(levelName);
		}
	}
	
	private void LoadLevelWithFadeInvoke(){
		Application.LoadLevel (loadLevelName);
	}
	
	public void LoadNextLevelWithFade(){
		if (fade) {
			Invoke ("LoadNextLevel", fade.BeginFade (1));
		} else {
			Debug.Log ("fade component not found on gameObject!");
			LoadNextLevel();
		}
	}

	public void LoadNextLevel(){
		Debug.Log ("LoadNextLevel()");
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		if (sceneIndex > SceneManager.sceneCountInBuildSettings-1) {
			sceneIndex = 1;
		}
		Debug.Log ("LoadNextLevel()" + sceneIndex.ToString());
		SceneManager.LoadScene(sceneIndex);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
