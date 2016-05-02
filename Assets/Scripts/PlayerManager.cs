using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : Entity {

    public float jumpForce = 10f;
    public float airModifier = 5f;
    public float restitutionScale = 1.1f;
	private bool hasDoubleJumped = false;
	private bool isInAir = false;
	private bool hasDoubleJumpPowerup = false;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
    }
    
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

	void Update(){
		if (IsGrounded ()) {
			hasDoubleJumped = false;
			isInAir = false;
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, jumpForce, 0f));
				isInAir = true;
				Debug.Log ("Jumping");
			}
		} else {
			if ((isInAir == true && hasDoubleJumped == false && hasDoubleJumpPowerup == true)) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					
					rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);;

					GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, jumpForce, 0f));
					hasDoubleJumped = true;
					Debug.Log ("Double jumping");
				}
			}
		}
	}

// Update is called once per frame
void FixedUpdate () {
        Vector3 toTranslate = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0f, 0f);
        
            //GetComponent<Rigidbody>().transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        
            //Vector3 force = new Vector3(Input.GetAxis("Horizontal")*speed * airModifier * Time.deltaTime, 0, 0);
            //if(force.x < 0 && GetComponent<Rigidbody>().velocity.x > 0 || force.x > 0 && GetComponent<Rigidbody>().velocity.x < 0) {
            //    force.x *= restitutionScale;
            //}
            //GetComponent<Rigidbody>().AddForce(force);
        
        GetComponent<Rigidbody>().transform.Translate(toTranslate);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Lose") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else if (other.gameObject.tag == "JumpEnemy") {
			Rigidbody r = other.gameObject.GetComponent<Rigidbody> ();
			//r.AddForce (new Vector3(0f, 500f, 0f));
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "DoubleJump") {
			hasDoubleJumpPowerup = true;
			SpecialEffectsHelper.Instance.PowerUp(other.gameObject.transform.position);
			Destroy (other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log("touched with "+other.gameObject.name);
		if (other.gameObject.tag == "JumpEnemy") {
			Debug.Log ("adding force");
			//Vector3 destination = Vector3.right * 5f;
			//other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, destination, 1f * Time.deltaTime);
			//StartCoroutine (smooth_move (Vector3.right, .25f, other.gameObject));
			//other.gameObject.transform.position.Set(
			other.rigidbody.AddForce (new Vector3(0f, 500f, 0f));
		}else if (other.gameObject.tag == "DoubleJump") {
			hasDoubleJumpPowerup = true;
		}
	}
				IEnumerator smooth_move(Vector3 direction,float speed, GameObject gameObj){
					float startime = Time.time;
					Vector3 start_pos = gameObj.transform.position; //Starting position.
					Vector3 end_pos = gameObj.transform.position + direction; //Ending position.

					while (start_pos != end_pos && ((Time.time - startime)*speed) < 1f) { 
						float move = Mathf.Lerp (0,1, (Time.time - startime)*speed);

						gameObj.transform.position += direction*move;

						yield return null;
					}
				}
		
}
