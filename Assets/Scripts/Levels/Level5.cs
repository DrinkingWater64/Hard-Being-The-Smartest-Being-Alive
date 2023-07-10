using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour, ILevel
{
    [SerializeField]
    private GameObject _key1;
    [SerializeField]
    private GameObject _key2;
    [SerializeField] private GameObject _key3;


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
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
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

        if (_key1.GetComponent<Item_Key>().keyCollected == true && _key2.GetComponent<Item_Key>().keyCollected && _key2.GetComponent<Item_Key>().keyCollected)
        {
            Debug.Log("Key collected");
            bagel.SetActive(true);
        }
    }
}
