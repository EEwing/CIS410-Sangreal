using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float startPositionX = 3.9f;
	public float startPositionY = 2.05f;
	public float startPositionZ = -0.06f;
	public float startRotationX = -5f;
	public float startRotationY = 270f;
	public float startRotationZ = 0f;
	//public float startScaleX = 1f;
	//public float startScaleY = 1f;
	//public float startScaleZ = 1f;

	public float finishPositionX = 0f;
	public float finishPositionY = 44.5f;
	public float finishPositionZ = -114.5f;
	public float finishRotationX = 13.5f;
	public float finishRotationY = 0f;
	public float finishRotationZ = 0f;
	//public float finishScaleX = 1f;
	//public float finishScaleY = 1f;
	//public float finishScaleZ = 1f;

	private Vector3 startP;
	private Vector3 finishP;

	private Vector3 startR;
	private Vector3 finishR;

	private Quaternion _targetRotation = Quaternion.identity;

	public float TransitionSpeed = 0.05f;
	public float anglePerTurn = 1f; 

	private float elapsedTime;

	// Use this for initialization

	void Awake() {
		startP = new Vector3(startPositionX, startPositionY, startPositionZ);
		finishP = new Vector3 (finishPositionX, finishPositionY, finishPositionZ);

		startR = new Vector3(startRotationX, startRotationY, startRotationZ);
		finishR = new Vector3 (finishRotationX, finishRotationY, finishRotationZ);

		transform.position = new Vector3(startPositionX, startPositionY, startPositionZ);

		_targetRotation = Quaternion.Euler(finishR);
	}

	private void Update()
	{
		//if (transform.position != finishP) {


		elapsedTime += Time.deltaTime;
		if (elapsedTime > .5f) {  	//Look at the heroin for half a second.
			//if (transform.rotation == Quaternion.Euler(finishR)) {

			transform.rotation = Quaternion.Slerp (transform.rotation, _targetRotation, anglePerTurn * Time.deltaTime);

			if (elapsedTime > 0.5f) {  	// If you've started tunring already, start pulling back.
			transform.position = Vector3.Lerp (transform.position, finishP, Time.deltaTime * TransitionSpeed);
			}
			//transform.position = Vector3.Lerp(transform.position, finishP, Time.deltaTime * TransitionSpeed);

		}

		if (elapsedTime > 1.2) {  							// After this amount of time,
			TransitionSpeed = TransitionSpeed + 0.001f;  // this speeds up camera so it pulls out faster.
		}

		
	}
}
