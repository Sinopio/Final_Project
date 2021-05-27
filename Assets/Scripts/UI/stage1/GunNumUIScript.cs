using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNumUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject rifle;
    [SerializeField]
    private GameObject pistol;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject grenade;
    [SerializeField]
    private GameObject injection;

    private void Update()
    {
        checkNum();
    }

    void checkNum()
    {
        switch(PlayerState.Instance.invenNum)
        {
            case 1:
                rifle.SetActive(true);
                pistol.SetActive(false);
                knife.SetActive(false);
                grenade.SetActive(false);
                injection.SetActive(false);
                break;
            case 2:
                rifle.SetActive(false);
                pistol.SetActive(true);
                knife.SetActive(false);
                grenade.SetActive(false);
                injection.SetActive(false);
                break;
            case 3:
                rifle.SetActive(false);
                pistol.SetActive(false);
                knife.SetActive(true);
                grenade.SetActive(false);
                injection.SetActive(false);
                break;
            case 10:
                rifle.SetActive(false);
                pistol.SetActive(false);
                knife.SetActive(false);
                grenade.SetActive(true);
                injection.SetActive(false);
                break;
            case 11:
                rifle.SetActive(false);
                pistol.SetActive(false);
                knife.SetActive(false);
                grenade.SetActive(false);
                injection.SetActive(true);
                break;

        }
    }
}
