using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float tapForce = 12f;
    public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
            rb.velocity = Vector2.up * tapForce;
        }	
	}
}
