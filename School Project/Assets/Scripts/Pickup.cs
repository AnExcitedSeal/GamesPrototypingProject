using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    Manager gameManager;
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyObject(gameObject);
            gameManager.UpdateScore();
        }
    }
}
