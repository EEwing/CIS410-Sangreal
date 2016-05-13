using UnityEngine;
using System.Collections;



public class MouseHover : MonoBehaviour {
	public Sprite oldSprite;
	public Sprite newSprite;
	// Use this for initialization
	void Start () {
		//renderer.material.color = Color.black;
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
		GetComponent<SpriteRenderer>().sprite = newSprite;
		//renderer.material.color = Color.yellow;
	}

	void OnMouseExit () {
		//renderer.material.color = Color.black;
		GetComponent<SpriteRenderer>().sprite = oldSprite;
	}


}
