/*
Dalhousie CSS Game Jam 
Fall 2016
Amelia Stead
*/

using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public float attackDamage = 10.0f;
	GameObject player; 
	PlayerHealth playerHealth;
	MonsterHealth enemyHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <MonsterHealth> ();
		playerInRange = false;
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
			Attack ();
		}
	}

	void OnTriggerEnter(Collider other) {
		print ("Entered");
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Attack() {
		timer = 0;
		playerHealth.TakeDamage (attackDamage);
	}
}
