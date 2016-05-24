using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
	public bool isStart;
	public bool isQuit;
	public string nextLevel;
	public GameObject gameover;

	// Use this for initialization
	void Start () {
		gameover = GameObject.FindWithTag("Respawn");
		if (gameover != null) {
			nextLevel = gameover.name;
			Destroy (gameover);
		} else
			nextLevel = "Level 1";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseUp(){
		if (isStart) {
			SceneManager.LoadScene (nextLevel);
		}
		if (isQuit) {
			Application.Quit ();
		}
	}
}
