using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{

    public void GoToPlay()
    {
        StartCoroutine(LoadSceneAfterDelay("Play", 1f));
    }

    public void GoToAbout()
    {
        StartCoroutine(LoadSceneAfterDelay("About", 1f));
    }

    public void ExitApp()
    {
        StartCoroutine(QuitAfterDelay(1f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

}
