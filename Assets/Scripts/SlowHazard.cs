using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.UIElements.ToolbarMenu;

public class SlowHazard : MonoBehaviour
{
    [SerializeField]
    private float decrementRate;

    [SerializeField]
    private float intervalRate;
    private Variant variant = null;
    private bool isInTrigger = false;
    private float previousFloat = 0f;
    private Coroutine decrementCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        variant = other.GetComponent<Variant>();
        if (variant != null )
        {
            previousFloat = variant.GetComponent<NavMeshAgent>().speed;
            variant.GetComponent<NavMeshAgent>().speed = 1.5f;
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (variant != null && other.gameObject == variant.gameObject)
        {

            variant.GetComponent<NavMeshAgent>().speed = previousFloat;
        }
    }
}
