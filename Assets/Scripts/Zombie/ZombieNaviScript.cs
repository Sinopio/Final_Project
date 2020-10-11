using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNaviScript : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    ZombieSectorScript zombieSectorScript;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieSectorScript = GetComponent<ZombieSectorScript>();
    }

    private void Update()
    {
        perceivePlayer();
    }

    void perceivePlayer()
    {
        if(zombieSectorScript.isCollision)
        {
            transform.LookAt(player.transform);
            agent.SetDestination(player.transform.position);
        }
        else
            agent.SetDestination(gameObject.transform.position);
    }

}
