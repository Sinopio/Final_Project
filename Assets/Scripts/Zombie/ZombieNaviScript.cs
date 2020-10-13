using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNaviScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject rayPosition;
    private NavMeshAgent agent;
    private ZombieSectorScript zombieSectorScript;
    private ZombieRayScript zombieRayScript;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieSectorScript = GetComponent<ZombieSectorScript>();
        zombieRayScript = rayPosition.GetComponent<ZombieRayScript>();
    }

    private void Update()
    {
        perceivePlayer();
        followPlayer();
    }

    void perceivePlayer()
    {
        if(zombieSectorScript.isCollision)
        {
            transform.LookAt(player.transform);
            //agent.SetDestination(player.transform.position);
        }
        //else
            //agent.SetDestination(gameObject.transform.position);
    }

    void followPlayer()
    {
        if(zombieRayScript.onSight)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(gameObject.transform.position);
        }
    }
}