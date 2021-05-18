using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManagerScript : MonoBehaviour
{
    // 총 정보 리스트
    public List<GunInfo> deck = new List<GunInfo>();

    private void Start()
    {
        applyUpgrade();
    }

    void applyUpgrade()
    {
        //라이플 데미지
        deck[0].gunDmg += UpgradeScript.Instance.deck[0].nowUpgrade1 * 10;
        //라이플 장탄
        deck[0].gunAmmo += (int)UpgradeScript.Instance.deck[0].nowUpgrade2 * 5;
        deck[0].ammoNum += (int)UpgradeScript.Instance.deck[0].nowUpgrade2 * 5;
        //피스톨 데미지
        deck[1].gunDmg += UpgradeScript.Instance.deck[1].nowUpgrade1 * 8;
        //피스톨 장탄
        deck[1].gunAmmo += (int)UpgradeScript.Instance.deck[1].nowUpgrade2 * 5;
        deck[1].ammoNum += (int)UpgradeScript.Instance.deck[1].nowUpgrade2 * 5;
        //칼 데미지
        deck[2].gunDmg += UpgradeScript.Instance.deck[2].nowUpgrade1 * 15;
    }
}
