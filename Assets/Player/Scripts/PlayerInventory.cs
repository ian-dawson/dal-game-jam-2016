/*
Dalhousie CSS Game Jam 
Fall 2016
Amelia Stead
*/

using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
	GameObject player;
	Camera _camera;
	public Weapon weapon1;
	public Weapon weapon2;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		weapon1 = GameObject.Find("Pistol").GetComponent<Pistol>();
		_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

		Vector3 cameraPos = _camera.transform.position;
		weapon1.transform.position = new Vector3(cameraPos.x+1.5f, cameraPos.y-1, cameraPos.z+1);
		weapon1.transform.SetParent (_camera.transform);
		weapon2 = null;
	}
}

