using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float XSensitivity = 5.0f;
	public float YSensitivity = 4.0f;

	private float _rotationX = 0;
	private Camera _camera;

	// Use this for initialization
	void Start () {
		_camera = gameObject.GetComponentInChildren<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		_rotationX -= Input.GetAxis ("Mouse Y") * YSensitivity;
		_rotationX = Mathf.Clamp (_rotationX, -90f, 90f);

		float delta = Input.GetAxis ("Mouse X") * XSensitivity;
		float rotationY = transform.localEulerAngles.y + delta;

		transform.localEulerAngles = new Vector3 (0, rotationY, 0);
		_camera.transform.localEulerAngles = new Vector3 (_rotationX, 0, 0);
	}
}
