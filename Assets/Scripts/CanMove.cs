using UnityEngine;
using System.Collections;

public class CanMove : MonoBehaviour {

	public Transform orginalParent;
	private PolygonCollider2D polyCollider;

	void Awake (){
		orginalParent = gameObject.transform.parent;
	}

	void OnTriggerStay2D(Collider2D colliderObject) {
		if(colliderObject.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Return))
		{
			Debug.Log ("Pickup Cloud");
			gameObject.transform.parent = colliderObject.gameObject.transform;
			if (polyCollider == null)
			{
				//polyCollider = gameObject.AddComponent<PolygonCollider2D>();
			}
		}
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyUp(KeyCode.Return))
		{
			Debug.Log ("Drop Cloud");
			gameObject.transform.parent = orginalParent;
			if (polyCollider != null)
			{
				Destroy(polyCollider);
			}
		}
	}
}
