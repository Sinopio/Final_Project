using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Knife;
    [SerializeField]
    private GameObject Rifle;
    [SerializeField]
    private GameObject Shotgun;
    [SerializeField]
    private GameObject Pistol;
    [SerializeField]
    private GameObject Grenade;
    [SerializeField]
    private GameObject Injector;

    private void Update()
    {
        switch (PlayerState.Instance.invenNum)
        {
            case 1:
                Knife.SetActive(false);
                Rifle.SetActive(true);
                Shotgun.SetActive(false);
                Pistol.SetActive(false);
                Grenade.SetActive(false);
                Injector.SetActive(false);
                break;

            case 2:
                Knife.SetActive(false);
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                Pistol.SetActive(true);
                Grenade.SetActive(false);
                Injector.SetActive(false);
                break;
            case 3:
                Knife.SetActive(true);
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                Pistol.SetActive(false);
                Grenade.SetActive(false);
                Injector.SetActive(false);
                break;
            case 10:
                Knife.SetActive(false);
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                Pistol.SetActive(false);
                Grenade.SetActive(true);
                Injector.SetActive(false);
                break;
            case 11:
                Knife.SetActive(false);
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                Pistol.SetActive(false);
                Grenade.SetActive(false);
                Injector.SetActive(true);
                break;
        }
    }
}