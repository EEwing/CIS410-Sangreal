using UnityEngine;
using System.Collections;

public class Level3platformactivate : MonoBehaviour {
	public GameObject plat;


	void OnTriggerEnter(Collider other) {
		plat.SetActive(true);
	}
}
