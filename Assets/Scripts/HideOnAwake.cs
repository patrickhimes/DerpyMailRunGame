using UnityEngine;
using System.Collections;

public class HideOnAwake : MonoBehaviour {
	//Because it's easier to manipulate visible objects in Unity,
	// this script is useful because it will automatically hide these objects 
	// when the game starts

	private Renderer[] childRenderers;
	// Use this for initialization
	void Awake () {

		childRenderers = gameObject.GetComponentsInChildren<Renderer>();

		foreach (Renderer childRenderer in childRenderers) {
			childRenderer.enabled = false;
		}
	}
}
