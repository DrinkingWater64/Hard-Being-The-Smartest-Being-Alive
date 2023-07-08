using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{
    //Reality info
    [SerializeField]
    private GameObject _world;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _ghost;
    [SerializeField]
    private Camera _camera;

    public Combat combatSystem;



    public bool keyCollected = false;

    private void Awake()
    {
        combatSystem = GameObject.Find("CombatSystem").GetComponent<Combat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player overlapped");
        if (other.CompareTag("Player"))
        {
            keyCollected = true;
            HandlePlayerInteraction();
        }
    }

    private void HandlePlayerInteraction()
    {
        combatSystem.SpawnOnNextTurn(gameObject.transform.position, _world.transform.position, _player, _ghost, _camera);
        gameObject.SetActive(false);
        Debug.Log("Player overlapped");
    }
}
