using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private RaycastHit hit;
    private NavMeshAgent agent;
    private string groundTag = "Walkable";
    public Combat _combat;

    // Start is called before the first frame update
    void Start()
    {
        _combat = GameObject.Find("CombatSystem").GetComponent<Combat>();
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
                if(agent.SetDestination(hit.point) == true)
                {
                    _combat.nextPosition = hit.point;
                    return true;
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
        else
        {
            return false;
        }
    }
}
