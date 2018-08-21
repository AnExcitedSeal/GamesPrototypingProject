using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MenuCube : MonoBehaviour {


    Rigidbody2D rb;
    GameObject gm;
    float jump = 200;
    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 7;
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(Vector3.right * speed);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jump")
        {
            rb.AddForce(Vector3.up * jump);
        }
        if (collision.gameObject.name == "BadFloor")
        {
            DestroyObject(gameObject);
            gm.GetComponent<MainMenu>().Restart();
        }
        if (collision.gameObject.name == "Border")
        {
            DestroyObject(gameObject);
            gm.GetComponent<MainMenu>().Restart();

        }
    }
}
