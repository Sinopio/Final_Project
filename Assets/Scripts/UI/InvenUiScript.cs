using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenUiScript : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultGun;
    [SerializeField]
    private GameObject pickGun;
    [SerializeField]
    private GameObject defaultKit;
    [SerializeField]
    private GameObject pickKit;
    [SerializeField]
    private GameObject defaultGrenade;
    [SerializeField]
    private GameObject pickGrenade;

    private void OnEnable()
    {
        defaultGun.SetActive(true);
        pickGun.SetActive(false);
        defaultKit.SetActive(true);
        pickKit.SetActive(false);
        defaultGrenade.SetActive(true);
        pickGrenade.SetActive(false);
    }

    private void Update()
    {
        setUI();
    }

    void setUI()
    {
        switch(PlayerState.Instance.invenNum)
        {
            case 0:
                defaultGun.SetActive(true);
                pickGun.SetActive(false);
                defaultKit.SetActive(true);
                pickKit.SetActive(false);
                defaultGrenade.SetActive(true);
                pickGrenade.SetActive(false);
                break;
            case 1:
                defaultGun.SetActive(false);
                pickGun.SetActive(true);
                defaultKit.SetActive(true);
                pickKit.SetActive(false);
                defaultGrenade.SetActive(true);
                pickGrenade.SetActive(false);
                break;
            case 2:
                defaultGun.SetActive(true);
                pickGun.SetActive(false);
                defaultKit.SetActive(true);
                pickKit.SetActive(false);
                defaultGrenade.SetActive(true);
                pickGrenade.SetActive(false);
                break;
            case 3:
                defaultGun.SetActive(true);
                pickGun.SetActive(false);
                defaultKit.SetActive(true);
                pickKit.SetActive(false);
                defaultGrenade.SetActive(false);
                pickGrenade.SetActive(true);
                break;
            case 4:
                defaultGun.SetActive(true);
                pickGun.SetActive(false);
                defaultKit.SetActive(false);
                pickKit.SetActive(true);
                defaultGrenade.SetActive(true);
                pickGrenade.SetActive(false);
                break;
        }
    }
}
