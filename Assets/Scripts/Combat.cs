using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Combat : MonoBehaviour
{
    public GamePhase gamePhase = GamePhase.PLAYERTURN;

    [SerializeField]
    private float threshold;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Camera _camera;


    private bool hasAgentReached = false;
    // Start is called before the first frame update
    void Start()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gamePhase == GamePhase.PLAYERTURN)
        {
            HandlePlayerTurn();
        }
        else if (gamePhase == GamePhase.AGENTMOVE)
        {
            HandleAgentMove();
        }

    }

    private bool HasReachedDestination()
    {
        float remainingDistance = Vector3.Distance(agent.destination, agent.transform.position);
        if (remainingDistance < threshold)
        {
            Debug.Log("Has Reached");
            return true;
        }

        Debug.Log("Has not Reached");
        return false;
    }

    private void HandlePlayerTurn()
    {
        Time.timeScale = .10f;
        MoveAgent();
        Debug.Log("Handling PLayer turn");
    }

    private void HandleAgentMove()
    {
        Time.timeScale = 1f;
        hasAgentReached = HasReachedDestination();
        if (hasAgentReached)
        {
            SwitchState();
        }
        Debug.Log("Handling agent turn");
    }

    private void SwitchState()
    {
        if (gamePhase == GamePhase.PLAYERTURN)
        {
            gamePhase = GamePhase.AGENTMOVE;
        }
        else if (gamePhase == GamePhase.AGENTMOVE)
        {
            gamePhase = GamePhase.PLAYERTURN;
        }
    }


    private void MoveAgent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            bool canGo = agent.gameObject.GetComponent<Movement>().MoveTo(ray);
            if (canGo)
            {
                gamePhase = GamePhase.AGENTMOVE;
                HandleAgentMove();
            }
        }
    }


}

public enum GamePhase
{
    AGENTMOVE,
    PLAYERTURN
}

