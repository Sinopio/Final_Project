using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MobInfo
{
    public string mobName;
    public float mobHp;
    public float mobDmg;
    public float mobSpeed;

    public MobInfo(MobInfo mobInfo)
    {
        this.mobName = mobInfo.mobName;
        this.mobHp = mobInfo.mobHp;
        this.mobDmg = mobInfo.mobDmg;
        this.mobSpeed = mobInfo.mobSpeed;
    }
}
