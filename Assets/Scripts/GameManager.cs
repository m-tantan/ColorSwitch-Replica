using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Player player;
    public GameObject[] circles;
    public int numberOfCircles;
    public Levels levelManager;
    public GameObject[] colorChangers;
    public Text levelText;

    [SerializeField]
    private static int level = 1;
    [HideInInspector]
    public bool gameWon = false;

	void Awake()
    {
        BeginSingleton();
        levelManager.setupLevel(level);
        //levelText
    }
    void Start()
    {
        print("game manager started");
    }
    
    private void BeginSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }



    // Update is called once per frame
    void Update () {
        //levelText.text = "Level: " + level;
        if (gameWon)
        {
            level += 1;
            print(level);
            print("Game Manager Won!");
            levelManager.nextLevel(level);
            gameWon = false;
            player.resetPlayer();
        }
	}
}
