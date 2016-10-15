using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float walkSpeed = 5.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * walkSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * walkSpeed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, walkSpeed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		// Convert the movement vector from local space to world space
		movement = transform.TransformDirection (movement);
		// Move the character along the movement vector
		_charController.Move(movement);
	}
}
