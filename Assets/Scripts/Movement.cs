using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    private RaycastHit hit;
    private NavMeshAgent agent;
    private string groundTag = "Walkable";
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (Camera == null ) {
            Camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {

                    Debug.Log("pocho");
                if(hit.collider.CompareTag(groundTag)) {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
