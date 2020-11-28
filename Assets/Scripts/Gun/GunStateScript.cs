using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunManager;
    public int gunNumber;
    private GunManagerScript manager;

    public float gunDmgState;
    public int gunAmmoState;
    public int gunFullAmmoState;
    public int gunAmmoNum;

    [SerializeField]
    private GameObject gripIcon;

    private void OnEnable()
    {
        manager = gunManager.GetComponent<GunManagerScript>();
        gunDmgState = manager.deck[gunNumber].gunDmg;
        gunAmmoState = manager.deck[gunNumber].gunAmmo;
        gunFullAmmoState = manager.deck[gunNumber].gunFullAmmo;
        gunAmmoNum = manager.deck[gunNumber].ammoNum;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerState.Instance.medikitNum++;
                gripIcon.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
