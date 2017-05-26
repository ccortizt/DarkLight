    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 distance;

	
	void Start () {

        distance = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
	}
	
	void LateUpdate () {	
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + distance;		
	}
}
