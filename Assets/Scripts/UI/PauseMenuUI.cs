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


    [SerializeField]
    private AudioSource buttonFX;
    [SerializeField]
    

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

    // play the clip in audio source. Once the clip is played completely the resume game
    public void ResumeGame()
    {
        if (panel.activeSelf == true)
        {
            combat.gamePhase = combat.previousGamephase;
            panel.SetActive(false);
        }
    }

    // play the clip in audio source. Once the clip is played completely then go to Menu
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
