using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	Animator animator;

	/*
	void AnimateMotion (KeyCode key, int direction) {
		if (Input.GetKey (key)) {
			animator.SetInteger ("Direction", direction);
		}
	}
	*/

	void Start () {
		animator = this.GetComponent<Animator>();
	}

	void Update () {

		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		if (vertical > 0) {
			animator.SetInteger ("Direction", 0);
		}
		else if (vertical < 0) {
			animator.SetInteger ("Direction", 2);
		}
		else if (horizontal > 0) {
			animator.SetInteger ("Direction", 1);
		}
		else if (horizontal < 0) {
			animator.SetInteger ("Direction", 3);
		}


	}
}
