using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	
	public GameObject target; // object to look at or follow
	
	public float smoothTime = 0.1f;    // time for dampen
	public bool lockX;
	public bool lockY;
	public Vector2 velocity; // speed of camera movement
	public Transform Floor;
	public Transform Ceiling;
	public Transform LeftWall;
	public Transform RightWall;

	private Transform thisTransform; // camera Transform
	private float camRadialHeight; 
	private float camRadialWidth;
	private float XMax;
	private float XMin;
	private float YMax;
	private float YMin;

	void Awake (){
		if(!target)
			FindTarget();
	}

	// Use this for initialization
	void Start () {
		thisTransform = transform;

		//get camera's viewing area
		Camera cam = Camera.main;
		camRadialHeight = cam.orthographicSize;
		camRadialWidth = ((2f * cam.orthographicSize) * cam.aspect)/2f;

		//calulate limits
		XMin = LeftWall.position.x + camRadialWidth;
		XMax = RightWall.position.x - camRadialWidth;
		YMin = Floor.position.y + camRadialHeight;
		YMax = Ceiling.position.y - camRadialHeight;
	}
	
	// Update is called once per frame
	void Update () {
			
		if(!target)
				FindTarget();

		if (target)
		{
			float posX = Mathf.Clamp(target.transform.position.x, XMin, XMax);
			float posY = Mathf.Clamp(target.transform.position.y, YMin, YMax);

			if(lockX)
				posX = thisTransform.position.x;
			
			if(lockY)
				posY = thisTransform.position.y;

			thisTransform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, posX, ref velocity.x, smoothTime), Mathf.SmoothDamp(thisTransform.position.y, posY, ref velocity.y, smoothTime), thisTransform.position.z);
		}
	}

	void FindTarget(){
		target = GameObject.FindWithTag("Player");
	}
}
