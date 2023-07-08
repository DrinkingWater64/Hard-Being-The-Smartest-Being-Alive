using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level1 : MonoBehaviour, ILevel
{
    [SerializeField]
    private GameObject canvasObject;
    [SerializeField]
    private Item_Key_harmless item_Key_Harmless;
    [SerializeField]
    private GameObject bagelPrefab;

    //tutorial
    [SerializeField]
    private GameObject clickUI;
    [SerializeField]
    private GameObject gotoKeyUI;
    [SerializeField]
    private GameObject gotoBagelUI;
    [SerializeField]
    private GameObject player;



    private bool isBagelSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (item_Key_Harmless != null && item_Key_Harmless.keygot == true)
        {
            SpawnBagle();
        }
        Tutorial();
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
        GameObject.Find("CombatSystem").GetComponent<Combat>().gamePhase = GamePhase.PAUSEDGAME;
        canvasObject.SetActive(true);
    }

    private void Tutorial()
    {
        if (clickUI.activeSelf == true) {
            if (player.GetComponent<NavMeshAgent>().velocity != Vector3.zero) {
                gotoKeyUI.SetActive(true);
                clickUI.SetActive(false);
            }
        }
        if (gotoKeyUI.activeSelf == true && clickUI.activeSelf == false)
        {
            if (isBagelSpawned == true)
            {
                gotoKeyUI.SetActive(false);
                gotoBagelUI.SetActive(true);
            }
        }
        
    }
}
