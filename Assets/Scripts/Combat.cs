using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Combat : MonoBehaviour
{
    public GamePhase gamePhase = GamePhase.PLAYERTURN;

    [SerializeField]
    private float threshold;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Camera _camera;
    




    /**
     * Spawn prefabs
     */
    [SerializeField]
    private GameObject _SpawnPlayerPrefab;
    [SerializeField]
    private Camera _spawnCamera;
    private int _turnsToWaitForSpawn = 2;
    private int _turnsCountFromNow = 0;
    private bool _isSpawning = false;
    private Vector3 _spawnPosition;
    private bool hasAgentReached = false;


    /**
     * System objects
     */
    public DisplaySystem displaySystem;


    // Start is called before the first frame update
    void Start()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
        if (displaySystem == null)
        {
            displaySystem = GameObject.Find("displaySystem").GetComponent<DisplaySystem>();
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
        //Debug.Log(_turnsCountFromNow);

        //Spawn prefab here
        if (_isSpawning)
        {
            if (_turnsCountFromNow > _turnsToWaitForSpawn)
            {
                _turnsCountFromNow = 0;
            }
            if (_turnsCountFromNow == _turnsToWaitForSpawn)
            {
                _spawnCamera.gameObject.SetActive(true);
                Instantiate(_SpawnPlayerPrefab, new Vector3(_spawnPosition.x,_spawnPosition.y, _spawnPosition.z),Quaternion.identity);
                displaySystem.AddToCameraList(_spawnCamera);
                _isSpawning = false;
            }
        }
    }

    private bool HasReachedDestination()
    {
        float remainingDistance = Vector3.Distance(agent.destination, agent.transform.position);
        if (remainingDistance < threshold)
        {
            //Debug.Log("Has Reached");
            return true;
        }

        //Debug.Log("Has not Reached");
        return false;
    }

    private void HandlePlayerTurn()
    {
        Time.timeScale = .10f;
        MoveAgent();
        //Debug.Log("Handling PLayer turn");
    }

    private void HandleAgentMove()
    {
        Time.timeScale = 1f;
        hasAgentReached = HasReachedDestination();
        if (hasAgentReached)
        {
            _turnsCountFromNow++;
            SwitchState();
        }
        //Debug.Log("Handling agent turn");
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
                _turnsCountFromNow++;
                HandleAgentMove();
            }
        }
    }

    public void SpawnOnNextTurn(Vector3 position, GameObject playerPrefab, Camera spawnCam)
    {
        _spawnPosition = position;
        _spawnCamera = spawnCam;
        _SpawnPlayerPrefab = playerPrefab;
        _isSpawning = true;
    }
}

public enum GamePhase
{
    AGENTMOVE,
    PLAYERTURN
}

