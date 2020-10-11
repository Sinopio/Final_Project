using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateScript : MonoBehaviour
{
    public GameObject gunManager;
    public int gunNumber;
    private GunManagerScript manager;

    public float gunDmgState;
    public int gunAmmoState;
    public int gunFullAmmoState;
    public int gunAmmoNum;

    private void OnEnable()
    {
        manager = gunManager.GetComponent<GunManagerScript>();
        gunDmgState = manager.deck[gunNumber].gunDmg;
        gunAmmoState = manager.deck[gunNumber].gunAmmo;
        gunFullAmmoState = manager.deck[gunNumber].gunFullAmmo;
        gunAmmoNum = manager.deck[gunNumber].ammoNum;
    }
}
