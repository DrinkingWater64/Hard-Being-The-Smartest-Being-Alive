using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Combat combat;
    private float timescale;

    private void Start()
    {
        combat = GameObject.Find("CombatSystem").GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf == false)
            {
                combat.gamePhase = GamePhase.PAUSEDGAME;
                panel.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {
        if (panel.activeSelf == true)
        {
            combat.gamePhase = combat.previousGamephase;
            panel.SetActive(false);
        }
    }

    //Duplicate code, Refactor later
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
