using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoScript : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private GameObject gunManger;
    private GunManagerScript managerScript;

    private void Start()
    {
        managerScript = gunManger.GetComponent<GunManagerScript>();    
    }

    private void Update()
    {
        setAmmoText();
    }

    void setAmmoText()
    {
        switch(PlayerState.Instance.invenNum)
        {
            case 1:
                ammoText.text = managerScript.deck[0].gunAmmo + " / " + managerScript.deck[0].gunFullAmmo;
                break;

            case 3:
                ammoText.text = " - / - ";
                break;
        }
    }
}
