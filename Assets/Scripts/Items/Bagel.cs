using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bagel : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private ButtonSFX buttonsfx;

    public bool bagelTouched = false;

    private void Start()
    {
       level = GameObject.FindGameObjectWithTag("Level");
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnEnable()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonsfx.PlayClip();
            level.GetComponent<ILevel>().OnLevelComplete();
        }
    }
}
