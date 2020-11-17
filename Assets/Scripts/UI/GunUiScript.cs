using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUiScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text ammoText;
    GunStateScript gunStateScript;
    PlayerGunScript playerGunScript;

    [SerializeField]
    List<GameObject> gunType = new List<GameObject>();
    [SerializeField]
    List<GameObject> invenGunType = new List<GameObject>();
    [SerializeField]
    private int invenGunNum;

    private void Start()
    {
        playerGunScript = player.GetComponent<PlayerGunScript>();
    }

    private void Update()
    {
        activeGunui();
        getScript();
    }

    void activeGunui()
    {
        invenGunNum = playerGunScript.pickGunNum;
        switch (invenGunNum)
        {
            case -1:
                gunType[0].SetActive(false);
                gunType[1].SetActive(false);
                gunType[2].SetActive(false);
                gunType[3].SetActive(false);
                gunType[4].SetActive(true);
                gunType[5].SetActive(true);
                break;
            case 0:
                gunType[0].SetActive(true);
                gunType[1].SetActive(true);
                gunType[2].SetActive(false);
                gunType[3].SetActive(false);
                gunType[4].SetActive(false);
                gunType[5].SetActive(false);
                break;
            case 1:
                gunType[0].SetActive(false);
                gunType[1].SetActive(false);
                gunType[2].SetActive(true);
                gunType[3].SetActive(true);
                gunType[4].SetActive(false);
                gunType[5].SetActive(false);
                break;
        }
    }

    void getScript()
    {
        invenGunNum = playerGunScript.pickGunNum;
        switch (invenGunNum)
        {
            case 0:
                gunStateScript= invenGunType[0].GetComponent<GunStateScript>();
                ammoText.text = gunStateScript.gunAmmoState.ToString() + " / " +
gunStateScript.gunFullAmmoState.ToString();
                break;
            case 1:
                gunStateScript = invenGunType[1].GetComponent<GunStateScript>();
                ammoText.text = gunStateScript.gunAmmoState.ToString() + " / " +
gunStateScript.gunFullAmmoState.ToString();
                break;
        }
    }
}
