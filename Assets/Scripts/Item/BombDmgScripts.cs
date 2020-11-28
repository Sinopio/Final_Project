using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDmgScripts : MonoBehaviour
{
    ZombieState zombieState;
    [SerializeField]
    private float Dmg;

    private void Start()
    {
        zombieState = gameObject.GetComponentInParent<ZombieState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grenade")
        {
            zombieState.stateHp -= Dmg;
        }
    }
}
