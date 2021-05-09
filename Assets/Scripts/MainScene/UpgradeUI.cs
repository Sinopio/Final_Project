using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject upgradeManagerObj;
    [SerializeField]
    private GameObject UI1;
    [SerializeField]
    private GameObject UI2;

    private WeaponSelect weaponSelect;
    private UpgradeScript upgradeScript;

    [SerializeField]
    private GameObject[] obj;
    [SerializeField]
    private Text moneyText;

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
        upgradeScript = upgradeManagerObj.GetComponent<UpgradeScript>();
    }

    private void Update()
    {
        setUi();
    }

    void setUi()
    {
        moneyText.text = upgradeScript.money.ToString();
        switch (weaponSelect.objNum)
        {
            case 1://라이플
                //총 데미지
                //총 탄창
                obj[0].SetActive(true);
                obj[1].SetActive(false);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                UI1.SetActive(true);
                UI2.SetActive(true);

                upgradeName1.text = "Damage";
                cost1.text = "1000";
                upgradeBar1.fillAmount = upgradeScript.deck[0].nowUpgrade1 / upgradeScript.deck[0].maxUpgrade1;
                nomal1.text = upgradeScript.deck[0].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[0].maxUpgrade1.ToString();

                upgradeName2.text = "Ammo";
                cost2.text = "500";
                upgradeBar2.fillAmount = upgradeScript.deck[0].nowUpgrade2 / upgradeScript.deck[0].maxUpgrade2;
                nomal2.text = upgradeScript.deck[0].nowUpgrade2.ToString();
                max2.text = upgradeScript.deck[0].maxUpgrade2.ToString();
                break;
            case 2://피스톨
                //총 데미지
                //총 탄창
                obj[0].SetActive(false);
                obj[1].SetActive(true);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                UI1.SetActive(true);
                UI2.SetActive(true);

                upgradeName1.text = "Damage";
                cost1.text = "500";
                upgradeBar1.fillAmount = upgradeScript.deck[1].nowUpgrade1 / upgradeScript.deck[1].maxUpgrade1;
                nomal1.text = upgradeScript.deck[1].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[1].maxUpgrade1.ToString();

                upgradeName2.text = "Ammo";
                cost2.text = "300";
                upgradeBar2.fillAmount = upgradeScript.deck[1].nowUpgrade2 / upgradeScript.deck[1].maxUpgrade2;
                nomal2.text = upgradeScript.deck[1].nowUpgrade2.ToString();
                max2.text = upgradeScript.deck[1].maxUpgrade2.ToString();

                break;

            case 3://나이프
                //칼 데미지
                obj[0].SetActive(false);
                obj[1].SetActive(false);
                obj[2].SetActive(true);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                UI1.SetActive(true);
                UI2.SetActive(false);

                upgradeName1.text = "Damage";
                cost1.text = "500";
                upgradeBar1.fillAmount = upgradeScript.deck[2].nowUpgrade1 / upgradeScript.deck[2].maxUpgrade1;
                nomal1.text = upgradeScript.deck[2].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[2].maxUpgrade1.ToString();
                break;

            case 4://수류탄
                //수류탄 데미지
                obj[0].SetActive(false);
                obj[1].SetActive(false);
                obj[2].SetActive(false);
                obj[3].SetActive(true);
                obj[4].SetActive(false);
                obj[5].SetActive(false);

                UI1.SetActive(true);
                UI2.SetActive(false);

                upgradeName1.text = "Damage";
                cost1.text = "1000";
                upgradeBar1.fillAmount = upgradeScript.deck[3].nowUpgrade1 / upgradeScript.deck[3].maxUpgrade1;
                nomal1.text = upgradeScript.deck[3].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[3].maxUpgrade1.ToString();
                break;

            case 5://치료제
                //치료량
                obj[0].SetActive(false);
                obj[1].SetActive(false);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(true);
                obj[5].SetActive(false);

                UI1.SetActive(true);
                UI2.SetActive(false);

                upgradeName1.text = "Heal Volume";
                cost1.text = "800";
                upgradeBar1.fillAmount = upgradeScript.deck[4].nowUpgrade1 / upgradeScript.deck[4].maxUpgrade1;
                nomal1.text = upgradeScript.deck[4].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[4].maxUpgrade1.ToString();
                break;

            case 6://플레이어
                //hp통
                //이동속도
                obj[0].SetActive(false);
                obj[1].SetActive(false);
                obj[2].SetActive(false);
                obj[3].SetActive(false);
                obj[4].SetActive(false);
                obj[5].SetActive(true);

                UI1.SetActive(true);
                UI2.SetActive(true);

                upgradeName1.text = "HP Max";
                cost1.text = "1000";
                upgradeBar1.fillAmount = upgradeScript.deck[5].nowUpgrade1 / upgradeScript.deck[5].maxUpgrade1;
                nomal1.text = upgradeScript.deck[5].nowUpgrade1.ToString();
                max1.text = upgradeScript.deck[5].maxUpgrade1.ToString();

                upgradeName2.text = "Speed";
                cost2.text = "1200";
                upgradeBar2.fillAmount = upgradeScript.deck[5].nowUpgrade2 / upgradeScript.deck[5].maxUpgrade2;
                nomal2.text = upgradeScript.deck[5].nowUpgrade2.ToString();
                max2.text = upgradeScript.deck[5].maxUpgrade2.ToString();
                break;

        }
    }


    public void Upgrade1()
    {
        switch (weaponSelect.objNum)
        {
            case 1:
                if (upgradeScript.money >= 1000
                    && upgradeScript.deck[0].nowUpgrade1 < upgradeScript.deck[0].maxUpgrade1
                    )
                {
                    upgradeScript.deck[0].nowUpgrade1++;
                    upgradeScript.money -= 1000;
                }
                break;

            case 2:
                if (upgradeScript.money >= 500
                    && upgradeScript.deck[1].nowUpgrade1 < upgradeScript.deck[1].maxUpgrade1
                    )
                {
                    upgradeScript.deck[1].nowUpgrade1++;
                    upgradeScript.money -= 500;
                }
                break;

            case 3:
                if (upgradeScript.money >= 500
                    && upgradeScript.deck[2].nowUpgrade1 < upgradeScript.deck[2].maxUpgrade1
                    )
                {
                    upgradeScript.deck[2].nowUpgrade1++;
                    upgradeScript.money -= 500;
                }
                break;

            case 4:
                if (upgradeScript.money >= 1000
                    && upgradeScript.deck[3].nowUpgrade1 < upgradeScript.deck[3].maxUpgrade1
                    )
                {
                    upgradeScript.deck[3].nowUpgrade1++;
                    upgradeScript.money -= 1000;
                }
                break;

            case 5:
                if (upgradeScript.money >= 800
                    && upgradeScript.deck[4].nowUpgrade1 < upgradeScript.deck[4].maxUpgrade1
                    )
                {
                    upgradeScript.deck[4].nowUpgrade1++;
                    upgradeScript.money -= 800;
                }
                break;

            case 6:
                if (upgradeScript.money >= 1000
                    && upgradeScript.deck[5].nowUpgrade1 < upgradeScript.deck[5].maxUpgrade1
                    )
                {
                    upgradeScript.deck[5].nowUpgrade1++;
                    upgradeScript.money -= 1000;
                }
                break;
        }
    }

    public void Upgrade2()
    {
        switch (weaponSelect.objNum)
        {
            case 1:
                if (upgradeScript.money >= 500
                    && upgradeScript.deck[0].nowUpgrade2 < upgradeScript.deck[0].maxUpgrade2
                    )
                {
                    upgradeScript.deck[0].nowUpgrade2++;
                    upgradeScript.money -= 500;
                }
                break;

            case 2:
                if (upgradeScript.money >= 300
                    && upgradeScript.deck[1].nowUpgrade2 < upgradeScript.deck[1].maxUpgrade2
                    )
                {
                    upgradeScript.deck[1].nowUpgrade2++;
                    upgradeScript.money -= 300;
                }
                break;

            case 6:
                if (upgradeScript.money >= 1200
                    && upgradeScript.deck[5].nowUpgrade2 < upgradeScript.deck[5].maxUpgrade2
                    )
                {
                    upgradeScript.deck[5].nowUpgrade2++;
                    upgradeScript.money -= 1200;
                }
                break;
        }
    }
    /*
    public void UpgradeRifle1()
    {
        if(upgradeScript.money >= 1000)
        {
            upgradeScript.deck[0].nowUpgrade1++;
            upgradeScript.money -= 1000;
        }
    }

    public void UpgradeRifle2()
    {
        if (upgradeScript.money >= 500)
        {
            upgradeScript.deck[0].nowUpgrade2++;
            upgradeScript.money -= 500;
        }
    }

    public void UpgradePistol1()
    {
        if (upgradeScript.money >= 500)
        {
            upgradeScript.deck[1].nowUpgrade1++;
            upgradeScript.money -= 500;
        }
    }

    public void UpgradePistol2()
    {
        if (upgradeScript.money >= 300)
        {
            upgradeScript.deck[1].nowUpgrade2++;
            upgradeScript.money -= 300;
        }
    }

    public void UpgradeKnife1()
    {
        if (upgradeScript.money >= 500)
        {
            upgradeScript.deck[2].nowUpgrade1++;
            upgradeScript.money -= 500;
        }
    }

    public void UpgradeGrenade1()
    {
        if (upgradeScript.money >= 1000)
        {
            upgradeScript.deck[3].nowUpgrade1++;
            upgradeScript.money -= 1000;
        }
    }

    public void UpgradeInjection1()
    {
        if (upgradeScript.money >= 800)
        {
            upgradeScript.deck[4].nowUpgrade1++;
            upgradeScript.money -= 800;
        }
    }

    public void UpgradePlayer1()
    {
        if (upgradeScript.money >= 1000)
        {
            upgradeScript.deck[5].nowUpgrade1++;
            upgradeScript.money -= 1000;
        }
    }

    public void UpgradePlayer2()
    {
        if (upgradeScript.money >= 1200)
        {
            upgradeScript.deck[5].nowUpgrade2++;
            upgradeScript.money -= 1200;
        }
    }*/
}
