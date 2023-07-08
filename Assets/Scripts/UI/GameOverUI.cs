using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public bool isGameOver = false;
    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (panel.activeSelf == false)
            {
                panel.SetActive(true);
            }
        }
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
