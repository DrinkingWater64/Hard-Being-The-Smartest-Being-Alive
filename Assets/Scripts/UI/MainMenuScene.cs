using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    public void GoToPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
