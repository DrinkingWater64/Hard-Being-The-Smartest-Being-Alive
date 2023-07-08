using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bagel : MonoBehaviour
{
    [SerializeField] private GameObject level;
    public bool bagelTouched = false;

    private void Start()
    {
       level = GameObject.FindGameObjectWithTag("Level");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            level.GetComponent<ILevel>().OnLevelComplete();
        }
    }
}
