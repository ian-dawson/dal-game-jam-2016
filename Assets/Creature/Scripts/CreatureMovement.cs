using UnityEngine;
using System.Collections;

public class CreatureMovement : MonoBehaviour {

	private GameObject player;

	//speed and gravity
	public float speed = 6.0f;
	public float gravity = -9.8f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}

	// Update is called once per frame
	void Update () {
		print(player.transform.position); 
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 0.07f); 
		transform.LookAt (player.transform.position);
	}
}
