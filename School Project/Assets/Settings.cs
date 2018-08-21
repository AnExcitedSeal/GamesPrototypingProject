using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour {

    Resolution[] resolutions;

    public TMP_Dropdown dropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        dropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentIndex;
        dropdown.RefreshShownValue();
    }

    public void SetResolution(int res)
    {
        Resolution resolution = resolutions[res];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
