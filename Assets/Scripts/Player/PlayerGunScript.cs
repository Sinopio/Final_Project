using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunObject;
    private GunStateScript gunState;
    public bool pickAvailable;
    [SerializeField]
    private int dropgunNum;
    public int pickGunNum;
    public float pickGunDmg;

    [SerializeField]
    private GameObject gun0;
    [SerializeField]
    private GameObject gun1;

    private void Start()
    {
        pickAvailable = false;
        pickGunNum = -1;
    }

    private void Update()
    {
        getGunscript();
        pickupGun();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Gun")
        {
            pickAvailable = true;
            gunObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gun")
        {
            pickAvailable = false;
            gunObject = null;
        }
    }

    void pickupGun()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(pickAvailable)
            {
               switch (dropgunNum)
                {
                    case 0:
                        pickGunNum = 0;
                        break;
                    case 1:
                        pickGunNum = 1;
                        break;
                }
            }
        }
    }

    void getGunscript()
    {
        if(gunObject != null)
        {
            gunState = gunObject.GetComponent<GunStateScript>();
            dropgunNum = gunState.gunNumber;
        }

        else
        {
            dropgunNum = -1;
        }
    }
}
