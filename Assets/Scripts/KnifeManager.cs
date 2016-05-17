using UnityEngine;
using System.Collections;

public class KnifeManager : MonoBehaviour {
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		i++;
		if (i > 500) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		Destroy (gameObject);
	}
}
