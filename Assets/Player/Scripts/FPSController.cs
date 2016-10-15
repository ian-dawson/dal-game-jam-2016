using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float walkSpeed = 5.0f;
	public float jumpStrength = 10.0f;
	public float gravityMultiplier = 1.0f;

	private CharacterController _charController;
	private float prevYSpeed;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float walkX = Input.GetAxis ("Horizontal") * walkSpeed;
		float walkZ = Input.GetAxis ("Vertical") * walkSpeed;

		Vector3 movement = new Vector3 (walkX, 0, walkZ);
		movement = Vector3.ClampMagnitude (movement, walkSpeed);

		if (_charController.isGrounded) {
			prevYSpeed = 0.0f;
			if (Input.GetKey (KeyCode.Space)) {
				prevYSpeed = jumpStrength;
			}
		} else {
			movement.y = prevYSpeed + Physics.gravity.y * gravityMultiplier;
			prevYSpeed = movement.y;
		}

		movement *= Time.deltaTime;
		// Convert the movement vector from local space to world space
		// Move the character along the movement vector
		_charController.Move(transform.TransformDirection (movement));
	}
}
