using UnityEngine;
using System.Collections;

public class CreatureMovement : MonoBehaviour {

	private GameObject player;

	//speed and gravity
	public float speed = 6.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
        //print (Mathf.Abs((player.transform.position - transform.position).x) + Mathf.Abs((player.transform.position - transform.position).z));
        if ((Mathf.Abs ((player.transform.position - transform.position).x) + Mathf.Abs ((player.transform.position - transform.position).z)) > 1.0f) { 
            Vector3 dir = (player.transform.position - transform.position);
            Vector3 movement = dir.normalized * 0.07f;
            GetComponent <CharacterController> ().Move (movement);
            transform.LookAt (player.transform.position);
        } else {
            //CONTACT ACTIONS/ANIMATIONS?
        }
    }


}
