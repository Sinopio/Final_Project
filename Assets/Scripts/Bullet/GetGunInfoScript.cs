using System.Collections;
using System.Collections.Generic;
using Unity.MPE;
using UnityEngine;

public class GetGunInfoScript : MonoBehaviour
{
    PlayerGunScript playerGunScript;
    ZombieState zombieState;
    GunManagerScript gunManagerScript;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gunManager;
    private int gunNum;

    private void Start()
    {
        playerGunScript = player.GetComponent<PlayerGunScript>();
        zombieState = gameObject.GetComponentInParent<ZombieState>();
        gunManagerScript = gunManager.GetComponent<GunManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gunNum = playerGunScript.pickGunNum;
        if (other.tag == "Bullet")
        {
            zombieState.stateHp -= gunManagerScript.deck[gunNum].gunDmg;
        }
    }
}
