using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGetGrenadeDmgScript : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;
    public float GrenadeDmg;
    private ZombieState zombieState;

    private void Start()
    {
        zombieState = zombie.GetComponent<ZombieState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grenade")
        {
            zombieState.stateHp -= GrenadeDmg;
        }
    }
}
