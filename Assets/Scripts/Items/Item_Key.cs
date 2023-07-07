using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key : MonoBehaviour
{

    public Combat combatSystem;

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

            HandlePlayerInteraction();
        }
    }

    private void HandlePlayerInteraction()
    {
        combatSystem.SpawnOnNextTurn(gameObject.transform.position);
        Destroy(gameObject);
        Debug.Log("Player overlapped");
    }
}
