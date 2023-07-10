using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public AudioSource audioSource;
    [SerializeField] GameObject parent;

    private bool hpGone = false;
    [SerializeField] ButtonSFX hpLow;

    private bool startedPlayying = false;

    public Combat combat;
    // Start is called before the first frame update
    void Start()
    {
        combat = GameObject.Find("CombatSystem").GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity != Vector3.zero)
        {
            if (startedPlayying == false)
            {
                audioSource.Play();
                startedPlayying = true;
            }
        }else if (agent.velocity == Vector3.zero)
        {
            if (startedPlayying == true)
            {
                audioSource.Stop();
                startedPlayying = false;
            }
        }
        
    }
}
