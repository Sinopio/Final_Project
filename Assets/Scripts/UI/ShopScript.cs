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


    private PlayerMove playerMove;
    private bool uiActive;
    private void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        shopUI.SetActive(false);
        uiActive = false;
    }

    private void Update()
    {
        setShopUI();
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
        Debug.Log("DmgUp");
    }

    public void UpgradeHp()
    {
        PlayerState.Instance.Hp += 20;
        PlayerState.Instance.MaxHp += 20;
    }

    public void UpgradeSpeed()
    {
        PlayerState.Instance.speed += 1f;
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
