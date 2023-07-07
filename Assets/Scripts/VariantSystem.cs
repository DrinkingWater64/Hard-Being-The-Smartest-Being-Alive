using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class VariantSystem : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> variantList = new List<GameObject>();



    [SerializeField]
    public Combat _combatSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject variant in variantList)
            {
                if (true)
                {
                    Debug.Log("in AGENTMOVE");
                    if (!_combatSystem.hasAgentReached)
                    {
                        variant.GetComponent<NavMeshAgent>().SetDestination(_combatSystem.nextPosition + variant.GetComponent<Variant>().worldOffset);
                    }
                }
            }
        }
    }

    //    if (Input.GetMouseButtonDown(0))
    //{
    //    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
    //    bool canGo = agent.gameObject.GetComponent<Movement>().MoveTo(ray);
    //    if (canGo)
    //    {
    //        gamePhase = GamePhase.AGENTMOVE;
    //        _turnsCountFromNow++;
    //        HandleAgentMove();
    //    }
    //}
}
