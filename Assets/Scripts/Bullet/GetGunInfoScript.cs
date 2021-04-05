using System.Collections;
using System.Collections.Generic;
using Unity.MPE;
using UnityEngine;

public class GetGunInfoScript : MonoBehaviour
{
    ZombieState zombieState;

    GunManagerScript gunManagerScript;

    [SerializeField]
    private GameObject gunManager;

    private void Start()
    {
        zombieState = gameObject.GetComponentInParent<ZombieState>();
        gunManagerScript = gunManager.GetComponent<GunManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //gunNum = playerGunScript.pickGunNum;
        if (other.tag == "Bullet")
        {
            zombieState.stateHp -= gunManagerScript.deck[PlayerState.Instance.invenNum - 1].gunDmg;
        }
    }
}
