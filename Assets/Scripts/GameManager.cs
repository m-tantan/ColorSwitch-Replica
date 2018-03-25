using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Player player;
    public GameObject[] circles;
    public Levels levelManager;
    public TextMeshProUGUI  levelText;

    [SerializeField]
    public static int level = 1;
    [HideInInspector]
    public bool gameWon = false;

	void Awake()
    {

        BeginSingleton();
        levelManager.setupLevel(level);
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
        levelText.text = "Level: " + level;
        if (gameWon)
        {
            FindObjectOfType<AudioManager>().playSound("NextLevel");
            print("Beat level: " + level);
            level += 1;
            levelManager.nextLevel(level);
            gameWon = false;
            player.resetPlayer();
        }
	}
}
