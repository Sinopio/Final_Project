using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorManager;
    [SerializeField]
    private GameObject shopUI;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text itemInfo;

    [SerializeField]
    private Text dmgUpText;
    [SerializeField]
    private Text speedUpText;
    [SerializeField]
    private GameObject gunmanager;
    private GunManagerScript gunManagerScript;
    private float speedNum = 100;
    private float dmgNum = 100;


    private PlayerMove playerMove;
    private bool uiActive;
    private void Start()
    {
        speedNum = 100;
        dmgNum = 100;
        playerMove = player.GetComponent<PlayerMove>();
        gunManagerScript = gunmanager.GetComponent<GunManagerScript>();
        shopUI.SetActive(false);
        uiActive = false;
    }

    private void Update()
    {
        setShopUI();
        upgradeText();
    }

    void upgradeText()
    {
        dmgUpText.text = dmgNum + " %";
        speedUpText.text = speedNum + " %";
    }

    void setShopUI()
    {
        if(Input.GetKeyDown(KeyCode.M) && !uiActive)
        {
            uiActive = true;
            shopUI.SetActive(true);
            cursorManager.SetActive(false);
            playerMove.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.N) && uiActive)
        {
            uiActive = false;
            shopUI.SetActive(false);
            cursorManager.SetActive(true);
            playerMove.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UpgradeDmg()
    {
        gunManagerScript.deck[0].gunDmg *= 1.1f;
        gunManagerScript.deck[1].gunDmg *= 1.1f;
        gunManagerScript.deck[2].gunDmg *= 1.1f;
        gunManagerScript.deck[3].gunDmg *= 1.1f;
        dmgNum += 10;
        
    }

    public void UpgradeHp()
    {
        PlayerState.Instance.Hp += 20;
        PlayerState.Instance.MaxHp += 20;

    }

    public void UpgradeSpeed()
    {
        PlayerState.Instance.speed = 1.1f;
        speedNum += 10;
        
    }

    public void BuyBullet()
    {
        Debug.Log("BuyBullet");
    }

    public void BuyGrenade()
    {
        PlayerState.Instance.grenadeNum++;
    }

    public void BuyFirstKit()
    {
        PlayerState.Instance.medikitNum++;
    }
}
