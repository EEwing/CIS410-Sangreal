using UnityEngine;
using System.Collections;

public class ParentingPlatform : MonoBehaviour {
    void OnCollisionEnter(Collision playerObject) {
        Debug.Log("enter moving platform");
        if (playerObject.gameObject.name.Contains("Player")) {
            playerObject.transform.parent = gameObject.transform;
        }
        if(playerObject.gameObject.CompareTag("Player")) {
           // ((PlayerManager)playerObject.gameObject.GetComponent<PlayerManager>()).Damage(10);
        }
    }
    int i = 0;
    void OnCollisionStay(Collision playerObject) {
		if (playerObject.gameObject.name.Contains ("Player")) {
			Debug.Log ("stay" + i++);
			if (playerObject.transform.position.y >= transform.position.y) {
				playerObject.transform.parent = gameObject.transform;
			} else {
				playerObject.transform.parent = null;
			}
		}
    }
    void OnCollisionExit(Collision playerObject) {
        Debug.Log("EXIT");
        if (playerObject.gameObject.name.Contains("Player")) {
            playerObject.transform.parent = null;
        }
    }
}
