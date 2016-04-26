using UnityEngine;
using System.Collections;

public class PlayerManager : Entity {

    public float jumpForce = 10f;
    public float airModifier = 5f;
    public float restitutionScale = 1.1f;

	// Use this for initialization
	void Start () {

    }
    
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

	void Update(){
		if (IsGrounded ()) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0f, jumpForce, 0f));
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
}
