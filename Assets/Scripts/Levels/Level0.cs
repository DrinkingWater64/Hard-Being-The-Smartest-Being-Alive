using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level0 : MonoBehaviour
{
    public GameObject[] objectsToCycle;
    private int currentIndex = 0;

    public void Start()
    {
        ActivateObject(currentIndex);
    }

    public void Next()
    {
        DeactivateObject(currentIndex);

        currentIndex++;
        if (currentIndex >= objectsToCycle.Length)
        {
            SceneManager.LoadScene("Play");
            return;
        }

        ActivateObject(currentIndex);
    }

    private void ActivateObject(int index)
    {
        if (index >= 0 && index < objectsToCycle.Length)
        {
            objectsToCycle[index].SetActive(true);
        }
    }

    private void DeactivateObject(int index)
    {
        if (index >= 0 && index < objectsToCycle.Length)
        {
            objectsToCycle[index].SetActive(false);
        }
    }
}
