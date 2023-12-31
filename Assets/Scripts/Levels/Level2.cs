using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour, ILevel
{
    [SerializeField]
    private GameObject _key1;
    [SerializeField] private GameObject keySound;
    [SerializeField]
    private GameObject bagel;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Combat combat;
    private bool isGameOver = false;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject variantTutorialUI;
    private bool isVariantMergeTutorialComplete = false;
    [SerializeField]
    private GameObject GamecompleteUI;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Variant>().hp <= 0)
        {
            Debug.Log("player dead");
            isGameOver = true;
            combat.gamePhase = GamePhase.PAUSEDGAME;
            gameOverUI.GetComponent<GameOverUI>().isGameOver = true;

        }

        if (_key1.GetComponent<Item_Key>().keyCollected == true) {
            Debug.Log("Key collected");
            bagel.SetActive(true);
            if (isVariantMergeTutorialComplete == false)
            {
                variantTutorialUI.SetActive(true);
                combat.gamePhase = GamePhase.PAUSEDGAME;
                isVariantMergeTutorialComplete=true;
            }
        }

        Debug.Log(Time.timeScale);
    }
    
    public void StopVariantTutorial()
    {
        variantTutorialUI?.SetActive(false);
        combat.gamePhase = combat.previousGamephase;
    }

    public void OnLevelComplete()
    {
        player.SetActive(false);
        GamecompleteUI.SetActive(true);
        combat.gamePhase=GamePhase.PAUSEDGAME;
    }
}
