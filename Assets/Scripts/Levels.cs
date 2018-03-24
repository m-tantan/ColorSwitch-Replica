using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    public GameObject[] circles;
    public GameObject[] colorChangers;
    public List<GameObject> activeCircles;
    public List<GameObject> activeChangers;
    public GameObject win;


    private Transform circleHolder;
    private Transform changersHolder;
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
        int numOfCircles = (int)Mathf.Floor(level / levelProgressRate);
        initiateCircles(numOfCircles);
        
	}

    private void initiateCircles(int numberOfCircles)
    {
        circleHolder = new GameObject("CircleHolder").transform;
        changersHolder = new GameObject("ChangerHolders").transform;

        float yLocation = 0;
        int lastType = 0;
        for (int i = 0; i < numberOfCircles; ++i)
        {
            int circleType = chooseCircleType(ref yLocation, lastType, i);
            addCircle(yLocation, i, circleType);
            
            if (i < numberOfCircles - 1) {
                if( circleType == 1 || (i == 0 && circleType == 1 ))  // meaning if big circle or this is the FIRST big circle
                    addColorChanger(yLocation + 8f , i);
                else
                    addColorChanger(yLocation + 4f , i);

            }

            lastType = circleType;
        }
        GameObject winGO = Instantiate(win, new Vector3(0f, yLocation + 9, 0f), Quaternion.identity);
        winGO.transform.localScale = new Vector3(0.3f, 0.3f, 0f);
        
    }

    private int chooseCircleType(ref float yLocation, int lastType, int i)
    {
        int circleType = Random.Range(0, circles.Length);


        switch (circleType)
        {
            case 0:

                if (i < 1)
                    break;
                else
                    if (lastType != circleType)
                {
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
                if (lastType != circleType)
                    yLocation -= 1.75f;
                yLocation += 16;
                break;
        }

        return circleType;
    }

    private void addCircle(float yLocation, int i, int circleType)
    {
        GameObject circle = circles[circleType];
        activeCircles.Add(Instantiate(circle, new Vector3(0f, yLocation, 0f), Quaternion.identity) as GameObject);
        activeCircles[i].transform.SetParent(circleHolder);
    }

    private void addColorChanger(float yLocation, int i)
    {
        GameObject colorChanger = colorChangers[0];
        activeChangers.Add(Instantiate(colorChanger, new Vector3(0f, yLocation, 0f), Quaternion.identity) as GameObject);
        activeChangers[i].transform.SetParent(changersHolder);
    }

    internal void nextLevel(int level)
    {
        activeCircles.Clear();
        activeChangers.Clear();
        int numOfCircles = (int)Mathf.Floor(level/levelProgressRate);
        initiateCircles(numOfCircles);
    }
}
