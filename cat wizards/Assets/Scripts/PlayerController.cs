using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public float speed = 1;

	[HideInInspector]
	public Vector3 target;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float horz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		Vector2 run = new Vector2 (horz, vert);
		if (run.sqrMagnitude > 1)
			run.Normalize ();

		run = run * speed;

		Vector2 vel = new Vector2 (rb.velocity.x, rb.velocity.z);

		if (Mathf.Abs (vel.sqrMagnitude) < Mathf.Abs (run.sqrMagnitude)) {
			vel = Vector2.Lerp (vel, run, 0.75f);
		}

		rb.velocity = new Vector3 (vel.x, rb.velocity.y, vel.y);
	}
}
