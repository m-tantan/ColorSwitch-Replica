using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    public GameObject[] circles;
    public List<GameObject> activeCircles;
    public Transform circleHolder;
    public GameObject win;
    public GameObject colorChanger;
    

    private float levelProgressRate = 2;
	// Use this for initialization
	void start() {
        
    }

    void destroyLevel() {
        for (int r = 0; r < activeCircles.Count; ++r) {
            Destroy(activeCircles[r]);
        }

    }
	// Update is called once per frame
	public void setupLevel (int level) {
        int numberOfCircles = (int)Mathf.Log(level, levelProgressRate);
        initiateCircles(numberOfCircles);
        
	}

    private void initiateCircles(int numberOfCircles)
    {
        circleHolder = new GameObject("CircleHolder").transform;
        float yLocation = 0;
        int lastType = 0;
        for (int i = 0; i < numberOfCircles; ++i)
        {
            int circleType = Random.Range(0, circles.Length);
            

            switch (circleType)
            {
                case 0:
                    
                    if (i < 1)
                        break;
                    else
                        if (lastType != circleType) {
                        yLocation += 3.5f;
                    }
                    yLocation += 10;
                    break;
                case 1:
                    if (i == 0)
                    {
                        yLocation = 3;
                        break;
                    }
                    yLocation += 16;
                    break;
            }
            GameObject circle = circles[circleType];
            
             activeCircles.Add(Instantiate(circle, new Vector3(0f, yLocation, 0f), Quaternion.identity) as GameObject);

            activeCircles[i].transform.SetParent(circleHolder);
            lastType = circleType;
        }
        GameObject winGO = Instantiate(win, new Vector3(0f, yLocation + 8, 0f), Quaternion.identity);
        winGO.transform.localScale = new Vector3(0.3f, 0.3f, 0f);
        
    }

    internal void nextLevel(int level)
    {
        for (var i = 0; i < activeCircles.Count; ++i)
        {
            
            Destroy(activeCircles[i]);
        }

        activeCircles.Clear();
        int numOfCircles = (int)Mathf.Log(level, levelProgressRate);
        initiateCircles(numOfCircles);
    }
}
