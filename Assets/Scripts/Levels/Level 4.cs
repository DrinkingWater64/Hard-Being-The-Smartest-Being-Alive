using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour, ILevel
{

    [SerializeField]
    private GameObject _key1;
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
    private GameObject GamecompleteUI;


    public void OnLevelComplete()
    {
        GamecompleteUI.SetActive(true);
        combat.gamePhase = GamePhase.PAUSEDGAME;

    }

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

        if (_key1.GetComponent<Item_Key>().keyCollected == true)
        {
            Debug.Log("Key collected");
            bagel.SetActive(true);
        }
    }
}
