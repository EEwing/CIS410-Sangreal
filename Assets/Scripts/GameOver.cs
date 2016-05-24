using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public string current;
	// Use this for initialization
	void Start () {
		current = SceneManager.GetActiveScene ().name;
		DontDestroyOnLoad(transform.gameObject);
		gameObject.name = current;

	}
	public string getScene(){
		return current;
	}
	


}
