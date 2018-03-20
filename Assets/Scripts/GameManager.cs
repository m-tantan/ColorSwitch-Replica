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
    
	void Awake() {
        instance = this;
        InstantiateCircles();

	}

    private void InstantiateCircles()
    {
        level++;
        if (level>0)
        {
            Debug.Log(level);
        }
        //for (int i = 0; i < numberOfCircles; ++i) {
        //    //GameObject circle = );
        //    circles[i] = circle;
            
        //}
    }

    private void BuildLevel() {
        numberOfCircles = (int)Mathf.Log(level);
        float lengthOfLevel = createLevel(numberOfCircles);
    }

    private float createLevel(int numberOfCircles)
    {
        float length = 0f;
            for (int i = 0; i < numberOfCircles; ++i) {
                
            }
        return length;
    }

    // Update is called once per frame
    void Update () {
	    	
	}
}
