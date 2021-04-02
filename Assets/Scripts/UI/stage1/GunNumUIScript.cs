using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNumUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject rifleOn;
    [SerializeField]
    private GameObject rifleOff;
    [SerializeField]
    private GameObject pistolOn;
    [SerializeField]
    private GameObject pistolOff;
    [SerializeField]
    private GameObject knifeOn;
    [SerializeField]
    private GameObject knifeOff;

    private void Update()
    {
        checkNum();
    }

    void checkNum()
    {
        switch(PlayerState.Instance.invenNum)
        {
            case 1:
                rifleOn.SetActive(true);
                rifleOff.SetActive(false);
                pistolOn.SetActive(false);
                pistolOff.SetActive(true);
                knifeOn.SetActive(false);
                knifeOff.SetActive(true);
                break;
            case 2:
                rifleOn.SetActive(false);
                rifleOff.SetActive(true);
                pistolOn.SetActive(true);
                pistolOff.SetActive(false);
                knifeOn.SetActive(false);
                knifeOff.SetActive(true);
                break;
            case 3:
                rifleOn.SetActive(false);
                rifleOff.SetActive(true);
                pistolOn.SetActive(false);
                pistolOff.SetActive(true);
                knifeOn.SetActive(true);
                knifeOff.SetActive(false);
                break;
        }
    }
}
