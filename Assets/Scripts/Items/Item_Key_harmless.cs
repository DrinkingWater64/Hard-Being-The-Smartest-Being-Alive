using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Key_harmless : MonoBehaviour
{
    public bool keygot = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keygot = true;
            OnKeyGot();
        }
    }

    private void OnKeyGot()
    {
        gameObject.SetActive(false);
    }
}
