/*
Dalhousie CSS Game Jam 
Fall 2016
Amelia Stead
*/

using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
	Weapon weapon1;
	//Weapon weapon2;
	PlayerInventory playerInventory;

	// Use this for initialization
	void Start() {
		playerInventory = GetComponent<PlayerInventory> ();
	}

	// Update is called once per frame
	void Update ()
	{
		weapon1 = playerInventory.weapon1;
		//weapon2 = playerInventory.weapon2;
		if (Input.GetMouseButtonDown (0)) {
			if (weapon1 != null) weapon1.Attack ();
		}
		if (Input.GetMouseButtonDown (1)) {
			//if (weapon2 != null) weapon2.Attack ();
		}
	}
}

