using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    private void Awake()
    {
        Invoke("Load", 5);
    }

    void Load()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
