using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManagerJL : Damageable {
	
    //public float jumpForce = 10f;
   // public float airModifier = 5f;
    //public float restitutionScale = 1.1f;
   // public float AttackLength = 10f;
   // public float AttackStrength = 10f;


	public GameObject knifePrefab;
	public GameObject avatar;
	private float elapsedTime;
	public Animator animator;
	private int facing = 1;

	private GameObject leftHand;
	private GameObject smallSword;
	public AudioClip swordSound;
    private bool hasDoubleJumped = false;
	//private bool isInAir = false;
	public bool hasDoubleJumpPowerup = false;
	public bool hasDashPowerup = false;
	//public int health;
    bool myanimationisplaying = false;
	private bool ThrowKnife = false;
	private bool MeleeAttack = false;

	//private Rigidbody rb;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		leftHand = GameObject.Find("l-finger-base");
		smallSword = GameObject.Find("Smallsword");
		smallSword.GetComponent<Collider>().enabled = false;
    }
    
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

	void Update(){
		elapsedTime += Time.deltaTime;
		//transform.localScale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Set animation to playing");
            myanimationisplaying = true;  //boolean value. declare it to false

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Set animation to playing = false");
            myanimationisplaying = false;

        }

        if (myanimationisplaying == true)
        {
            animator.ResetTrigger("stop");
          //  Debug.Log("Playing Animation");
            animator.Play("Armature|RunCycle");
        }
        else
        {
          //  Debug.Log("Triggering stop");
            animator.SetTrigger("stop");
        }

        //if (Input.GetKeyDown(KeyCode.Z)) {
           // Debug.Log("Trying to attack");
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //foreach(GameObject enemy in enemies) {
             ///   Vector3 diff = enemy.transform.position - transform.position;
             //   Debug.Log("Found an enemy @ " + diff);
             //   if (diff.magnitude < AttackLength) {
            //        ((Rigidbody)enemy.GetComponent<Rigidbody>()).AddForce(diff.normalized * AttackStrength);
            //        ((Damageable)enemy.GetComponent<Damageable>()).Damage(10);
            //    }
           // }
        //}/*
		if (Input.GetKey (KeyCode.Z)) {
				MeleeAttack = true;
			SoundManager.instance.RandomizeSfx (swordSound);
				animator.SetTrigger ("melee");
				smallSword.GetComponent<Collider>().enabled = true;
				//smallSword.GetComponent<Collider>().isTrigger = true;

				//if (animation ["throw"].normalizedTime > 0.33) {
				//leftHand.transform.parent = null;
				//Physics.IgnoreCollision (knife.GetComponent<Collider> (), GetComponent<Collider> ());
				//knife.GetComponent<Rigidbody> ().AddForce (Vector3.right * 750 + new Vector3 (0, 200, 0));
				//}

		}

		if (Input.GetKey (KeyCode.F)) {
			if (elapsedTime > 0.5) {
				elapsedTime = 0;
				ThrowKnife = true;
				animator.SetTrigger ("throw");


				//if (animation ["throw"].normalizedTime > 0.33) {
					//leftHand.transform.parent = null;
					//Physics.IgnoreCollision (knife.GetComponent<Collider> (), GetComponent<Collider> ());
					//knife.GetComponent<Rigidbody> ().AddForce (Vector3.right * 750 + new Vector3 (0, 200, 0));
				//}
			}
		}



		if (IsGrounded ()) {
			hasDoubleJumped = false;
			//isInAir = false;
			animator.SetTrigger ("land");
			if (Input.GetKeyDown (KeyCode.Space)) {
				//GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, jumpForce, 0f));
			//	isInAir = true;
				//Debug.Log ("Jumping");
				animator.SetTrigger ("jump");
			}
		} else {
			if ((hasDoubleJumped == false && hasDoubleJumpPowerup == true)) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					
					//rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);;

					//GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, jumpForce, 0f));
					hasDoubleJumped = true;
					Debug.Log ("Double jumping");
				}
			}
		}

		//if (Input.GetKeyDown (KeyCode.X) && IsGrounded() && hasDashPowerup == true) {
			//speed = 110f;
		//	Invoke ("reduceSpeed", 0.15f);
	//	}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") > 0) {
			facing = 1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			facing = -1;
		}
		Transform parent = transform.parent;
		transform.parent = null;
        //Quaternion targetRotation;
       // Vector3 toTranslate = new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1,1,1);
            
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
		if (elapsedTime > 0.16 && ThrowKnife == true) {
			elapsedTime = 0;
			ThrowKnife = false;
			GameObject knife = (GameObject)Instantiate (knifePrefab, transform.position + new Vector3 (0, 1, 0), transform.rotation);
			knife.GetComponent<KnifeManager>().facing = facing;
			knife.GetComponent<KnifeManager>().setFacing(facing);
			Physics.IgnoreCollision (knife.GetComponent<Collider> (), GetComponent<Collider> ());
			knife.GetComponent<Rigidbody> ().AddForce (Vector3.right * 750 * facing + new Vector3(0,200,0));
				}

		if (MeleeAttack = true) {
			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("melee") == false) {
				MeleeAttack = false;
				smallSword.GetComponent<Collider> ().enabled = false;
				//smallSword.GetComponent<Collider> ().isTrigger = false;
				// You have just leaved your state!
			}
		}
        //Debug.Log(toTranslate);
        //if(toTranslate.magnitude > 0.05)
        /*if (toTranslate != (new Vector3(0, 0, 0)))
        {
            if (IsGrounded())
            {
                Debug.Log("Setting running animation");
                animator.SetTrigger("running");
            }
        } else {
            Debug.Log("Setting stop running animation");
            animator.SetTrigger("stop");
        }*/
        //GetComponent<Rigidbody>().transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f));

        //Vector3 force = new Vector3(Input.GetAxis("Horizontal")*speed * airModifier * Time.deltaTime, 0, 0);
        //if(force.x < 0 && GetComponent<Rigidbody>().velocity.x > 0 || force.x > 0 && GetComponent<Rigidbody>().velocity.x < 0) {
        //    force.x *= restitutionScale;
        //}
        //GetComponent<Rigidbody>().AddForce(force);

        //GetComponent<Rigidbody> ().transform.Translate (toTranslate);
		transform.parent = parent;
			

	}

	void reduceSpeed(){
		speed = 10f;	
	}




}
   