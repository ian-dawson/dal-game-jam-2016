/*
Dalhousie CSS Game Jam 
Fall 2016
Amelia Stead
*/

using UnityEngine;
using System;

public class Pistol : Weapon
{
	Camera _camera;
	GameObject[] enemies;
	MonsterHealth monsterHealth;
	public float pistolDamage = 30;
	float timeBetweenAttacks = 1.0f;
	float timer;

	// Use this for initialization
	void Start () {
		_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		enemies = GameObject.FindGameObjectsWithTag ("Monster");
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	public override void Attack ()
	{	
		if (timer > timeBetweenAttacks) {
			timer = 0;
			Ray ray = _camera.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				GameObject obj = hit.transform.gameObject;
				if (Array.IndexOf (enemies, obj) != -1) {
					print ("hit");
					monsterHealth = obj.GetComponent<MonsterHealth> ();
					monsterHealth.TakeDamage (pistolDamage);
				}
			}
		}
	}
}

