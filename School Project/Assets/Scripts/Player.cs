using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    float fallMultiplier = 2.5f;

    float speed = 7;

    bool jumping;
    GameObject spawn;
    Rigidbody2D rigid;

    Manager manager;

    private void Awake() { rigid = gameObject.GetComponent<Rigidbody2D>(); }

    void Start()
    {
        jumping = false;
        spawn = GameObject.Find("SpawnPoint");
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            rigid.AddForce(Vector3.right * speed);

        if (Input.GetKey(KeyCode.A))
            rigid.AddForce(Vector3.left * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumping)
            {
                jumping = true;
                rigid.AddForce(Vector3.up * 270);
            }
        }

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadSceneAsync("MainMenu");

        if (rigid.velocity.y < 0)
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumping = false;
        }
        if (collision.gameObject.tag == "BadFloor")
        {
            manager.LoseLife();
            transform.position = spawn.transform.position;
        }
        if (collision.gameObject.tag == "Boundary")
        {
            manager.LoseLife();
            transform.position = spawn.transform.position;
        }
        if (collision.gameObject.tag == "BlueFloor" && collision.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            manager.LoseLife();
            transform.position = spawn.transform.position;
        }

    }
}
