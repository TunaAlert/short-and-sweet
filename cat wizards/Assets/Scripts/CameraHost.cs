using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHost : MonoBehaviour {

	public GameObject defaultTarget;

	private GameObject target;

	void Start () {
		SetDefaultTarget ();
	}

	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.2f);
	}

	public void SetTarget(GameObject t){
		target = t;
	}

	public void SetDefaultTarget(){
		target = defaultTarget;
	}
}
