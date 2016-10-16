using UnityEngine;
using System;

public class Shotgun : Weapon
{
	Camera _camera;
	GameObject[] enemies;
	MonsterHealth monsterHealth;
	float timer;
	bool playerInRange;
	GameObject player;
	public float shotgunDamage = 20;

	// Use this for initialization
	void Start () {
		_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		enemies = GameObject.FindGameObjectsWithTag ("Monster");
		timer = 0;
		player = GameObject.Find ("Player");
		playerInRange = false;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	public override void Attack ()
	{
		print ("Shoot shotgun");

		//shotgun has larger hit range
		Ray rayCenter = _camera.ScreenPointToRay(Input.mousePosition);
		Ray rayLeft = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth*9/20, _camera.pixelWidth/2, 0));
		Ray rayRight = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth*11/20, _camera.pixelWidth/2, 0));
		Ray rayUp = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth/2, _camera.pixelWidth*9/20, 0));
		Ray rayDown = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth/2, _camera.pixelWidth*11/20, 0));

		RaycastHit hit;

		if (Physics.Raycast (rayCenter, out hit)
			|| Physics.Raycast (rayLeft, out hit)
			|| Physics.Raycast (rayRight, out hit)
			|| Physics.Raycast (rayUp, out hit)
			|| Physics.Raycast (rayDown, out hit)) {
			GameObject obj = hit.transform.gameObject;
			if (Array.IndexOf(enemies, obj) != -1) {
				print ("hit");
				monsterHealth = obj.GetComponent<MonsterHealth> ();
				monsterHealth.TakeDamage (shotgunDamage);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			print ("On Shotgun");
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
}
