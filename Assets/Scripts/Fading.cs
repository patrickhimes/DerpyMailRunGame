using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour {

	public float fadeSpeed = 0.8f;

	private Image fadePanel;
	private Color currentColor = Color.black;
	private int fadeDir = -1;
	private float alpha = 1f;

	void Awake(){
		fadePanel = gameObject.GetComponent<Image> ();
		if (!fadePanel.enabled) {
			fadePanel.enabled = true;
		}
	}

	void Update(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		currentColor = new Color (currentColor.r, currentColor.g, currentColor.b, alpha);
		fadePanel.color = currentColor;

		
		if (alpha == 0) {
			fadePanel.enabled = false;
			Debug.Log("Fade Panel is invisible. Deactivate Panel Object");
		} else {
			fadePanel.enabled = true;
		}
	}

	public float BeginFade (int direction){
		fadeDir = direction;
		Debug.Log("fadedir set to: " + fadeDir.ToString());
		return (fadeSpeed);
	}

	void OnLevelWasLoaded(){
		BeginFade (-1);
	}
}
