using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Player player;
    public RotateCircle[] circles;
    public int numberOfCircles;

    [SerializeField]
    private int level = 1;
	// Use this for initialization
	void Awake() {
        instance = this;
        InstantiateCircles();

	}

    private void InstantiateCircles()
    {
        //for (int i = 0; i < numberOfCircles; ++i) {
        //    //GameObject circle = );
        //    circles[i] = circle;
            
        //}
    }

    // Update is called once per frame
    void Update () {
	    	
	}
}
