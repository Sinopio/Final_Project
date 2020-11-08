using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamageScript : MonoBehaviour
{
    ZombieState zombieState;
    private bool canDmg;

    private void Start()
    {
        zombieState = GetComponentInParent<ZombieState>();
    }

    private void OnEnable()
    {
        canDmg = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canDmg)
        {
            PlayerState.Instance.Hp -= zombieState.stateDmg;
            canDmg = false;
        }
    }
}
