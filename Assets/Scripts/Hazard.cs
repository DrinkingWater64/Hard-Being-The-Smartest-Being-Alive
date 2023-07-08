using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private float decrementRate;

    [SerializeField]
    private float intervalRate;
    private Variant variant = null;
    private bool isInTrigger = false;
    private Coroutine decrementCoroutine;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        variant = other.GetComponent<Variant>();
        if (variant != null && !isInTrigger)
        {
            isInTrigger = true;
            decrementCoroutine = StartCoroutine(DecrementRoutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (variant != null && other.gameObject == variant.gameObject)
        {
            isInTrigger = false;
            if (decrementCoroutine != null)
            {
                StopCoroutine(decrementCoroutine);
            }
        }
    }

    private IEnumerator DecrementRoutine()
    {
        while (true)
        {
            // Decrement the HP by the decrement rate
            variant.TakeDamage(decrementRate);
            Debug.Log("Deducting HP");

            // Wait for 10 seconds
            yield return new WaitForSeconds(intervalRate);
        }
    }
}
