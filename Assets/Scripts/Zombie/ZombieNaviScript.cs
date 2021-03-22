using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNaviScript : MonoBehaviour
{
    [SerializeField]
    private GameObject destination;

    private NavMeshAgent agent;
    private ZombieState zombieState;
    private Animator animator;
    private Rigidbody rig;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        zombieState = GetComponent<ZombieState>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        agent.SetDestination(destination.transform.position);
        setAgentSpeed();
    }

    void setAgentSpeed()
    {
        switch (zombieState.zombieState)
        {
            case 0: // Idle
                agent.speed = 0f;
                break;
            case 1: // inRay
                agent.speed = 5f;
                break;
            case 2: // Atk
                agent.speed = 0f;
                break;
            case 3: // 
                agent.speed = 1.3f;
                break;
            case 4: // inSoundSector
                agent.speed = 0.5f;
                break;
            case 5: // Die
                agent.speed = 0f;
                break;
            case 6: // alert
                agent.speed = 5f;
                break;
        }
    }
}