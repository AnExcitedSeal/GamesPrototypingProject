using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    GameObject spawn;

    private void Start()
    {
        spawn = GameObject.Find("PlayerSpawn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = spawn.transform.position;   
        }
    }
}
