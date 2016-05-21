using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : Damageable {

    public float restitutionScale = 1.1f;
    public float AttackLength = 10f;
    public float AttackStrength = 10f;

	public int health;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
    }

	void Update(){
        if(Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("Trying to attack");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies) {
                Vector3 diff = enemy.transform.position - transform.position;
                Debug.Log("Found an enemy @ " + diff);
                if (diff.magnitude < AttackLength) {
                    ((Rigidbody)enemy.GetComponent<Rigidbody>()).AddForce(diff.normalized * AttackStrength);
                    ((Damageable)enemy.GetComponent<Damageable>()).Damage(10);
                }
            }
        }
	}

	// Update is called once per frame
	void FixedUpdate () {

	}
		
	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Lose") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else if (other.gameObject.tag == "Enemy") {
			//I take damage here
			Damage (7);
		} else if (other.gameObject.tag == "DoubleJump") {
			GetComponent<PlayerMovementManager>().hasDoubleJumpPowerup = true;
			SpecialEffectsHelper.Instance.PowerUp (other.gameObject.transform.position);
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Dash") {
			GetComponent<PlayerMovementManager>().hasDashPowerup = true;
			SpecialEffectsHelper.Instance.PowerUp (other.gameObject.transform.position);
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Level2") {
			SceneManager.LoadScene ("Level 2");
		}
		else if (other.gameObject.tag == "Level3") {
			SceneManager.LoadScene ("Level 3");
		}
		else if (other.gameObject.tag == "Level4") {
			SceneManager.LoadScene ("Level 4");
		}
		else if (other.gameObject.tag == "Level5") {
			SceneManager.LoadScene ("Final Level");
		}
		else if (other.gameObject.tag == "Finish") {
			SceneManager.LoadScene ("MainMenu");
		}
	}


	void OnCollisionEnter(Collision other) {
		//Debug.Log("touched with "+other.gameObject.name);
		if (other.gameObject.tag == "JumpEnemy") {
			//Debug.Log ("adding force");
			//other.rigidbody.AddForce (new Vector3(0f, 500f, 0f));
		}else if (other.gameObject.tag == "DoubleJump") {
			GetComponent<PlayerMovementManager>().hasDoubleJumpPowerup = true;
		}
	}

    protected override void OnDeath() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
