using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGunScript : MonoBehaviour
{
    public GameObject player;
    PlayerGunScript playerGunScript;
    [SerializeField]
    List<GameObject> invenGun = new List<GameObject>();
    [SerializeField]
    private int invenGunNum;

    private void Start()
    {
        playerGunScript = player.GetComponent<PlayerGunScript>();
        invenGunNum = -1;
    }

    private void Update()
    {
        activeGun();
    }

    void activeGun()
    {
        invenGunNum = playerGunScript.pickGunNum;
        switch (invenGunNum)
        {
            case 0:
                invenGun[0].SetActive(true);
                invenGun[1].SetActive(false);
                break;
            case 1:
                invenGun[0].SetActive(false);
                invenGun[1].SetActive(true);
                break;
        }
    }
}
