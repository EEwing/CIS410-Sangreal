using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
	public bool isStart;
	public bool isQuit;
	public string nextLevel;

	// Use this for initialization
	void Start () {
	
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
