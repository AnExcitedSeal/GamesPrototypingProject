using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    float time = 100;
    GameObject start;
    public GameObject player;
    private AudioManager am;

    private void Start()
    {
        start = GameObject.Find("Start");
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.Play("Menu");
    }
    public void PlayButton()
    {
        am.Play("Button");
        SceneManager.LoadSceneAsync("Level1");
    }
    public void OptionsButton()
    {
        am.Play("Button");
        SceneManager.LoadSceneAsync("SettingsMenu");
    }
    public void QuitBttn()
    {
        am.Play("Button");
        Application.Quit();
    }

    public void Restart()
    {
        Invoke("Respawn", 3);
    }

    void Respawn()
    {
        Instantiate(player, start.transform.position, start.transform.rotation);
    }
}
