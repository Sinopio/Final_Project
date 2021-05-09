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
    private GameObject gunmanager;
    private GunManagerScript gunManagerScript;
    [SerializeField]
    private Text playerMoney;
    [SerializeField]
    private Text shopInfo;

    private PlayerMove playerMove;
    private bool uiActive;
    private void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        gunManagerScript = gunmanager.GetComponent<GunManagerScript>();
        shopUI.SetActive(false);
        uiActive = false;
    }

    private void Update()
    {
        setShopUI();
        setMoney();
    }

    void setMoney()
    {
        playerMoney.text = "" + PlayerState.Instance.money;
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

    public void BuyRifleBullet()
    {
        if(PlayerState.Instance.money >= 500)
        {
            gunManagerScript.deck[0].gunFullAmmo += gunManagerScript.deck[0].ammoNum;
            PlayerState.Instance.money -= 500;
        }
        else
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    public void BuyPistolBullet()
    {
        if (PlayerState.Instance.money >= 200)
        {
            gunManagerScript.deck[1].gunFullAmmo += gunManagerScript.deck[1].ammoNum;
            PlayerState.Instance.money -= 200;
        }
        else
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    public void BuyGrenade()
    {
        if (PlayerState.Instance.money >= 1000)
        {
            PlayerState.Instance.grenadeNum++;
            PlayerState.Instance.money -= 1000;
        }
        else
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    public void BuyFirstKit()
    {
        if (PlayerState.Instance.money >= 800)
        {
            PlayerState.Instance.medikitNum++;
            PlayerState.Instance.money -= 800;
        }
        else
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    public void GetOut()
    {
        uiActive = false;
        shopUI.SetActive(false);
        cursorManager.SetActive(true);
        playerMove.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void enterBuyRifleBullet()
    {
        shopInfo.text = "라이플의 총알을 구매합니다. \n\n\n\n\n\n $:500";
    }

    public void enterBuyPistolBullet()
    {
        shopInfo.text = "권총의 총알을 구매합니다. \n\n\n\n\n\n $:200";
    }

    public void enterBuyGrenade()
    {
        shopInfo.text = "수류탄을 구매합니다. \n\n\n\n\n\n $:1000";
    }

    public void enterBuyMedikit()
    {
        shopInfo.text = "체력회복약을 구매합니다. \n\n\n\n\n\n $:800";
    }

    public void exitButtonUi()
    {
        shopInfo.text = "편의점 아포칼립스에 어서오세요";
    }
}
