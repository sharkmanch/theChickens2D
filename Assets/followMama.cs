using UnityEngine;
using System.Collections;

public class followMama : MonoBehaviour {


	public Transform target;
	public float distance = 5f;
	public float height = 1.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void LateUpdate (){
		float currentHeight = transform.position.y;
		Vector3 pos = target.position - Vector3.forward * distance;
		pos.y = currentHeight;

	}
}
