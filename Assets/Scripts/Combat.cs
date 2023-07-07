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
    public NavMeshAgent agent;
    [SerializeField]
    private Camera _camera;




    /**
     * Spawn prefabs
     */
    [SerializeField]
    private GameObject _SpawnPlayerPrefab;
    [SerializeField]
    private GameObject _GhostPrefab;
    [SerializeField]
    private Camera _spawnCamera;
    private int _turnsToWaitForSpawn = 2;
    private int _turnsCountFromNow = 0;
    private bool _isSpawning = false;
    private Vector3 _spawnPosition;
    private Vector3 _worldOffset;

    public Vector3 nextPosition;
    public bool hasAgentReached = false;

    /**
     * System objects
     */
    public DisplaySystem displaySystem;
    public VariantSystem variantSystem;

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
                GameObject spawned = Instantiate(_SpawnPlayerPrefab, _spawnPosition+_worldOffset,Quaternion.identity);
                GameObject ghostSpawned = Instantiate(_GhostPrefab, transform.position, Quaternion.identity);
                ghostSpawned.GetComponent<Ghost>().SetOriginObject(spawned);
                ghostSpawned.GetComponent<Ghost>().worldOffset = _worldOffset;
                spawned.GetComponent<Variant>().worldOffset = _worldOffset;
                displaySystem.AddToCameraList(_spawnCamera);
                variantSystem.variantList.Add(spawned);
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

    public void SpawnOnNextTurn(Vector3 position, Vector3 worldOffset, GameObject playerPrefab, GameObject ghostObject,Camera spawnCam)
    {
        _spawnPosition = position;
        _worldOffset = worldOffset;
        _spawnCamera = spawnCam;
        _SpawnPlayerPrefab = playerPrefab;
        _GhostPrefab = ghostObject;
        _isSpawning = true;
    }
}

public enum GamePhase
{
    AGENTMOVE,
    PLAYERTURN
}

