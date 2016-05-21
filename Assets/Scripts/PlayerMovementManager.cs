using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementManager : Damageable {

	public float jumpForce = 10f;
	public float airModifier = 5f;

	public AudioClip jumpSound1;
	public AudioClip jumpSound2;

	private int facing = 1;

	public GameObject knifePrefab;
	private float elapsedTime;
    private float dashLimiter;

	private bool hasDoubleJumped = false;
	//private bool isInAir = false;
	public bool hasDoubleJumpPowerup = false;
	public bool hasDashPowerup = false;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.5f);
	}


	void Update(){
        dashLimiter += Time.deltaTime;
		elapsedTime += Time.deltaTime;
		if (Input.GetKey (KeyCode.F)) {
			if (elapsedTime > 0.5) {
				elapsedTime = 0;
				GameObject knife = (GameObject)Instantiate (knifePrefab, transform.position + new Vector3 (1, 1, 0), transform.rotation);
				knife.GetComponent<KnifeManager>().facing = facing;
				knife.GetComponent<KnifeManager>().setFacing(facing);
				Physics.IgnoreCollision (knife.GetComponent<Collider> (), GetComponent<Collider> ());
				knife.GetComponent<Rigidbody> ().AddForce (Vector3.right * 750 * facing + new Vector3(0,200,0));
			}
		}

		if (IsGrounded ()) {
			hasDoubleJumped = false;
			//isInAir = false;
			if (Input.GetKeyDown (KeyCode.Space)) {
				//Debug.Log (rb);
				rb.AddForce (new Vector3 (0f, jumpForce, 0f));
				SoundManager.instance.RandomizeSfx (jumpSound1);
				//isInAir = true;
				Debug.Log ("Jumping");
			}
		} else {
			if ((hasDoubleJumped == false && hasDoubleJumpPowerup == true)) {
				if (Input.GetKeyDown (KeyCode.Space)) {

					rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);;

					rb.AddForce (new Vector3 (0f, jumpForce, 0f));
					SoundManager.instance.RandomizeSfx (jumpSound2);
					hasDoubleJumped = true;
					Debug.Log ("Double jumping");
				}
			}
		}
			
		if (Input.GetKeyDown (KeyCode.X) && IsGrounded() && hasDashPowerup == true && dashLimiter > 3) {
            dashLimiter = 0;
			speed = 110f;
			Invoke ("reduceSpeed", 0.15f);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") > 0) {
			facing = 1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			facing = -1;
		}
		Vector3 toTranslate = new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0f, 0f);
		GetComponent<Rigidbody> ().transform.Translate (toTranslate);

	}

	void reduceSpeed(){
		speed = 10f;	
	}
}
