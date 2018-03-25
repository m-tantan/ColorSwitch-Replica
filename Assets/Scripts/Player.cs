using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public float tapForce = 12f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Color red;
    public Color blue;
    public Color green;
    public Color yellow;
    [HideInInspector]
    public String currColor;
    //private GameManager gameManager;

    void Start () {
        //gameManager = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.simulated = false;
        ColorChanger.SetRandomColor(this);
	}

    void Update () {

	    if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
            rb.simulated = true;
            rb.velocity = Vector2.up * tapForce;
            FindObjectOfType<AudioManager>().playSound("Tap");

        }
    }
  

    public void resetPlayer()
    {
       transform.position = new Vector3(0f, -6f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            //transform.position = new Vector3(transform.position.x, -4.741f, transform.position.z);
            rb.simulated = false;
            return;
        }

        if (other.tag == "ColorChanger")
        {
            ColorChanger.SetRandomColor(this);
            Destroy(other.gameObject);
            return; 
        }
        else if (other.tag == "Win") {
            rb.simulated = false;
            print("PlayerWon");
            GameManager.instance.gameWon = true;
            return;
        }
        else if (currColor != other.tag && other.tag != "Platform") {
            
            Debug.Log(other.tag);
            FindObjectOfType<AudioManager>().playSound("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
}
