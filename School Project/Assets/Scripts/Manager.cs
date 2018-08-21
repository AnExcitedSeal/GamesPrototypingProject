using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour {

    private int score;
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text gameOverText;
    [SerializeField]
    Image heart1;
    [SerializeField]
    Image heart2;


    GameObject player;
    int lives;

	void Start ()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Theme");
        player = GameObject.Find("Player");
        score = 0;
        lives = 2;
	}
    private void Update()
    {
        if (gameOverText.enabled && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (gameOverText.enabled && Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void UpdateScore()
    {
        ++score;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        //score = 0;
        //scoreText.text = score.ToString();
    }

    public void LoseLife()
    {
        if (lives == 2)
        {
            --lives;
            heart1.enabled = false;
        }
        else if (lives == 1)
        {
            --lives;
            heart2.enabled = false;
        }
        else
        {
            DestroyObject(player);
            gameOverText.enabled = true;

        }
    }
}

