using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInfoTextScript : MonoBehaviour
{
    [SerializeField]
    private Text shopInfo;

    public void enterDmgUp()
    {
        shopInfo.text = "총기 데미지를 10% 증가시킵니다. \n\n\n\n\n\n $:500";
    }

    public void enterHpUp()
    {
        shopInfo.text = "체력을 20 증가시킵니다. \n\n\n\n\n\n $:500";
    }

    public void enterSpeedUp()
    {
        shopInfo.text = "이동속도를 20% 증가시킵니다. \n\n\n\n\n\n $:500";
    }

    //-----------------------------------------------------------------------//
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
        shopInfo.text = "";
    }
}
