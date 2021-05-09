using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunInfo
{
    // 총기 이름
    public string gunName;
    // 총기 데미지
    public float gunDmg;
    // 총기 장탄수
    public int gunAmmo;
    // 총기 총 탄약 수
    public int gunFullAmmo;
    // 총기 한탄창 값
    public int ammoNum;

    // max dmg
    public float maxGunDmg;
    // max ammo
    public int maxGunAmmo;

    public GunInfo(GunInfo gunInfo)
    {
        this.gunName = gunInfo.gunName;
        this.gunDmg = gunInfo.gunDmg;
        this.gunAmmo = gunInfo.gunAmmo;
        this.gunFullAmmo = gunInfo.gunFullAmmo;
        this.maxGunDmg = gunInfo.maxGunDmg;
        this.maxGunAmmo = gunInfo.maxGunAmmo;
    }
}
