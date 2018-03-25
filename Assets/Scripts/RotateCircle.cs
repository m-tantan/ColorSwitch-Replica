using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateCircle : MonoBehaviour {
    public float rotateSpeed ;
    public bool isReverse;
    private RotateCircle parentCircle;
    public static int maxSpeed = 85;
    void Start()
    {
        if (transform.tag == "InsideCircle")
        {
            parentCircle = GetComponentInParent<RotateCircle>();
            resetSpeed(parentCircle);
        }
        else {

        
        rotateSpeed += Random.Range(70, maxSpeed);
        isReverse = Random.Range(0,10) > 5 ? true : false;
        if (isReverse)
            rotateSpeed *= -1f;
        }
    }

    private void resetSpeed(RotateCircle parentTag)
    {
        if ( parentTag.rotateSpeed > 0 )
            rotateSpeed += 2* parentTag.rotateSpeed;
            
        else
            rotateSpeed -= 2* parentTag.rotateSpeed;

    }

    // Update is called once per frame
    void Update () {
        
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);		
	}

}
