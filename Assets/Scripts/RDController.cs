using UnityEngine;
using System.Collections;

public class RDController : MonoBehaviour {
	protected Animator animator;

	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	public float airSpeed = 1f;
	public float lift = .1f;
	bool isGrounded = true;
	bool isCrawling = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask groundLayer;
	bool isFlying = false;
	bool facingRight = true;
	private float playerPreviousPosition;
	private Quaternion playerPreviousRotation;
	private int playerPreviousLevel = 0;
	private bool _canControl = true;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void Awake () {
		playerPreviousLevel = Application.loadedLevel;
	}

	void OnLevelWasLoaded(int thisLevel)
	{
		//find player spawn point
		SpawnPlayer[] spawnPoints = FindObjectsOfType(typeof(SpawnPlayer)) as SpawnPlayer[];
		foreach ( SpawnPlayer spawnPoint in spawnPoints){
			if(spawnPoint.sceneIndex == playerPreviousLevel) {
				GameObject spawn = GameObject.Find(spawnPoint.gameObject.name);
				//place player at this enterance
				transform.position = spawn.transform.position;

			}
		}

		playerPreviousLevel = thisLevel;
	}

	void Update () {
		
		if(animator && _canControl)
		{
			//toggle flight
			if(Input.GetButtonDown( "Fly" )) {
				isFlying = !isFlying;
				isGrounded = !isGrounded;
				animator.SetBool("IsFlying", isFlying );
				animator.SetTrigger( "TakeOff" );
			}

			if(isGrounded && Input.GetButtonDown( "Jump" ) && !isFlying) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
				animator.SetBool("IsGrounded", isGrounded );
			}

			if(isGrounded && Input.GetButtonDown( "Buck" ) && !isFlying) {
				animator.SetTrigger( "Buck" );
			}

			if(isGrounded && Input.GetButtonDown( "Shove" ) && !isFlying) {
				animator.SetTrigger( "Shove" );
			}

			if(isGrounded && Input.GetButtonDown( "Crawl" ) && !isFlying) {
				isCrawling = !isCrawling;
				animator.SetBool("Crawl", isCrawling );
			}
		}

	}

	void FixedUpdate()
	{
		if(animator)
		{
			//check ground
			if( !isFlying )
				isGrounded = Physics2D.OverlapCircle( groundCheck.position, groundRadius, groundLayer);

			animator.SetBool("IsGrounded", isGrounded );
			animator.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y );

			//disable controls if jumping
			if(!isFlying && !isGrounded) return;
			
			float moveh = 0;
			float movev =  0;

			if( _canControl ){
				moveh = Input.GetAxis("Horizontal"); //max value of 1
				movev = Input.GetAxis("Vertical"); //max value of 1
			}

			animator.SetFloat("Speed", Mathf.Abs(moveh));

			if( isGrounded ) //only use velocity to move while grounded
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveh * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

			if( isFlying )
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveh * airSpeed, (movev + lift) * airSpeed);


			if(moveh > 0 && !facingRight)
				Flip ();
			else if (moveh < 0 && facingRight)
				Flip ();

		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 spriteScale = transform.localScale;
		spriteScale.x *= -1;
		transform.localScale = spriteScale;
	}

	void SavePlayerLocation ( float relativePos) {
		playerPreviousPosition = relativePos;
	}

	public void EnableControls () {
		_canControl = true;
	}

	public void DisableControls () {
		_canControl = false;
	}
}
