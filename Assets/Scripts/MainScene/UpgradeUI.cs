using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gunManagerObj;

    private WeaponSelect weaponSelect;
    private GunManagerScript gunManager;

    [SerializeField]
    private GameObject[] obj;

    [SerializeField]
    private Image upgradeBar1;
    [SerializeField]
    private Text upgradeName1;
    [SerializeField]
    private Text nomal1;
    [SerializeField]
    private Text max1;
    [SerializeField]
    private Text cost1;

    [SerializeField]
    private Image upgradeBar2;
    [SerializeField]
    private Text upgradeName2;
    [SerializeField]
    private Text nomal2;
    [SerializeField]
    private Text max2;
    [SerializeField]
    private Text cost2;

    private void Start()
    {
        weaponSelect = gameObject.GetComponent<WeaponSelect>();
        gunManager = gunManagerObj.GetComponent<GunManagerScript>();
    }

    private void Update()
    {
        setUi();
        upgrade();
    }

    void setUi()
    {
        switch (weaponSelect.objNum)
        {
            case 1://라이플
                obj[0].SetActive(true);
                obj[1].SetActive(false);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                upgradeName1.text = "Damage";
                upgradeBar1.fillAmount = gunManager.deck[0].gunDmg / gunManager.deck[0].maxGunDmg;
                nomal1.text = "" + gunManager.deck[0].gunDmg;
                max1.text = "" + gunManager.deck[0].maxGunDmg;
                cost1.text = "1000";

                upgradeName2.text = "Ammo";
                upgradeBar2.fillAmount = gunManager.deck[0].gunAmmo / gunManager.deck[0].maxGunAmmo;
                nomal2.text = "" + gunManager.deck[0].gunAmmo;
                max2.text = "" + gunManager.deck[0].maxGunAmmo;
                cost2.text = "500";
                break;
            case 2://피스톨
                obj[0].SetActive(false);
                obj[1].SetActive(true);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                upgradeName1.text = "Damage";
                upgradeBar1.fillAmount = gunManager.deck[1].gunDmg / gunManager.deck[1].maxGunDmg;
                nomal1.text = "" + gunManager.deck[1].gunDmg;
                max1.text = "" + gunManager.deck[1].maxGunDmg;
                cost1.text = "700";

                upgradeName2.text = "Ammo";
                upgradeBar2.fillAmount = gunManager.deck[1].gunAmmo / gunManager.deck[1].maxGunAmmo;
                nomal2.text = "" + gunManager.deck[1].gunAmmo;
                max2.text = "" + gunManager.deck[1].maxGunAmmo;
                cost2.text = "300";
                break;
            case 3://나이프

                break;
            case 4://수류탄

                break;
            case 5://치료제

                break;
            case 6://이동속도

                break;

        }
    }

    void upgrade()
    {
        switch (weaponSelect.objNum)
        {
            case 1://라이플

                break;
            case 2://피스톨

                break;
            case 3://나이프

                break;
            case 4://수류탄

                break;
            case 5://치료제

                break;
            case 6://이동속도

                break;

        }
    }
}
