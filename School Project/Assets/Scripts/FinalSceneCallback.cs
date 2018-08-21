using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneCallback : MonoBehaviour {

    public void MainMenuClick()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
