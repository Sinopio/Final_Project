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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieState = GetComponent<ZombieState>();
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
                agent.speed = zombieState.stateSpeed*1.2f;
                break;
            case 2: // Atk
                agent.speed = 0f;
                break;
            case 3: // 
                agent.speed = zombieState.stateSpeed * 0.3f;
                break;
            case 4: // inSoundSector
                agent.speed = zombieState.stateSpeed * 0.4f;
                break;
            case 5: // Die
                agent.speed = 0f;
                break;
            case 6: // alert
                agent.speed = zombieState.stateSpeed * 1.4f;
                break;
        }
    }
}