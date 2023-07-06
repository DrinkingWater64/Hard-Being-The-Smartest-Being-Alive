using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private RaycastHit hit;
    private NavMeshAgent agent;
    private string groundTag = "Walkable";
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool MoveTo(Ray ray)
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(groundTag))
            {
                return agent.SetDestination(hit.point);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
