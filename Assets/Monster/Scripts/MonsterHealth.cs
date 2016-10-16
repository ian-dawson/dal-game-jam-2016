/*
Dalhousie CSS Game Jam 
Fall 2016
Amelia Stead
*/

using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour
{
	public float startingHealth = 100;
	public float currentHealth;
	bool isDead;

	// Use this for initialization
	void Start ()
	{
		currentHealth = startingHealth;
		isDead = false;
	}

	public void TakeDamage(float amount) {
		currentHealth -= amount;
		if (currentHealth < 0 && !isDead) {
			isDead = true;
			Death ();
		}
	}

	void Death() {
		print ("Monster did the dead.");
	}
}

