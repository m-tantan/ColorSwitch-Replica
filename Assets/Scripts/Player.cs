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
    private String currColor;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.simulated = false;
        SetRandomColor();
	}

    void Update () {

	    if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
            rb.simulated = true;
            rb.velocity = Vector2.up * tapForce;
        }	
	}
    private void SetRandomColor()
    {
        String current = currColor;
        int color = Random.Range(0, 4);

        switch (color)
        {
            case 0:
                currColor = "Red";
                sr.color = red;
                break;
            case 1:
                currColor = "Blue";
                sr.color = blue;

                break;
            case 2:
                currColor = "Green";
                sr.color = green;

                break;
            case 3:
                currColor = "Yellow";
                sr.color = yellow;

                break;
        }
        if (current == currColor)
        {
            SetRandomColor();
        }
        else return;
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
            SetRandomColor();
            Destroy(other.gameObject);
            return; 
        }
        else if (other.tag == "Win") {
            rb.simulated = false;
            return;
        }
        else if (currColor != other.tag && other.tag != "Platform") {
            
            Debug.Log(other.tag);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
}
