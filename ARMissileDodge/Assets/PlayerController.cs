using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private Animation anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float z = CrossPlatformInputManager.GetAxis ("Depth");

		Vector3 movement = new Vector3 (x, 0, z);

		rb.velocity = movement * 4f;

		if (x != 0 && z != 0) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x,Mathf.Atan2(x,z) * Mathf.Rad2Deg ,transform.eulerAngles.y);
		}
		if (x != 0 || z != 0) {
			anim.Play ("walk");
		} else {
			anim.Play ("idle");
		}

	}
}
