using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeInfo
{
    public string name;

    public float nowUpgrade1;
    public float maxUpgrade1;

    public float nowUpgrade2;
    public float maxUpgrade2;

    public UpgradeInfo(UpgradeInfo upgradeInfo)
    {
        this.name = upgradeInfo.name;

        this.nowUpgrade1 = upgradeInfo.nowUpgrade1;
        this.maxUpgrade1 = upgradeInfo.maxUpgrade1;

        this.nowUpgrade2 = upgradeInfo.nowUpgrade2;
        this.maxUpgrade2 = upgradeInfo.maxUpgrade2;
    }
}
