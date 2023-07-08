using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour, ILevel
{
    [SerializeField]
    private GameObject canvasObject;
    [SerializeField]
    private Item_Key_harmless item_Key_Harmless;
    [SerializeField]
    private GameObject bagelPrefab;

    private bool isBagelSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (item_Key_Harmless != null && item_Key_Harmless.keygot == true)
        {
            SpawnBagle();
        }
    }

    public void SpawnBagle()
    {
        if (isBagelSpawned == false)
        {
            isBagelSpawned = true;
            if (bagelPrefab.activeSelf == false)
            {

                bagelPrefab.SetActive(true);
            }
        }

    }

    public void OnLevelComplete()
    {
        Time.timeScale = 0f;
        canvasObject.SetActive(true);
    }
}
