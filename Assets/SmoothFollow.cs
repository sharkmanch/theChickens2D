using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 7.5f;
	// the height we want the camera to be above the target
	public float height = 1.2f;
	// How much we 
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;


	void LateUpdate (){
		// Early out if we don't have a target
		if (!target)
			return;

		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		float dt = Time.deltaTime;
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * dt);//Time.GetMyDeltaTime());

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * dt);//Time.GetMyDeltaTime());
		//System.Console.WriteLine("dt: {0}", dt);//Time.GetMyDeltaTime());
		//Debug.Log("dt: " + Time.deltaTime);

		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		//transform.position = target.position;
		Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
		pos.y = currentHeight;

		// Set the height of the camera
		transform.position = pos;

		// Always look at the target
		transform.LookAt (target);
	}
}
