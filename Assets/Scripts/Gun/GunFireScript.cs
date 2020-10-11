using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour
{
    GunStateScript gunStateScript;
    private bool canFire;
    private bool canReload;

    private void Start()
    {
        gunStateScript = GetComponent<GunStateScript>();
        canFire = true;
        canReload = true;
    }
    private void Update()
    {
        fireGun();
        checkCanFire();
        reloadGun();
    }

    void fireGun()
    {
        if(canFire && Input.GetMouseButtonDown(0))
        {
            gunStateScript.gunAmmoState--;
        }
    }

    void checkCanFire()
    {
        if(gunStateScript.gunAmmoState <= 0)
        {
            canFire = false;
        }
    }

    void reloadGun()
    {
        int i = 0;
        if(gunStateScript.gunAmmoState < gunStateScript.gunAmmoNum && canReload)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                i = gunStateScript.gunAmmoNum - gunStateScript.gunAmmoState;
                if (gunStateScript.gunFullAmmoState <= gunStateScript.gunAmmoNum)
                {
                    gunStateScript.gunAmmoState = gunStateScript.gunFullAmmoState;

                    canFire = true;
                    canReload = false;
                }
                else
                {
                    gunStateScript.gunAmmoState = gunStateScript.gunAmmoNum;
                    gunStateScript.gunFullAmmoState -= i;
                    canFire = true;
                    canReload = true;
                }
            }
        }
    }

}
