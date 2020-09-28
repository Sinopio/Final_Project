using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun_Info
{
    // 총기 이름
    public string Gun_Name;
    // 총기 데미지
    public float Gun_Dmg;
    // 총기 장탄수
    public float Gun_Ammo;
    // 총기 총 탄약 수
    public float Gun_Full_Ammo;

    public Gun_Info(Gun_Info gun_Info)
    {
        this.Gun_Name = gun_Info.Gun_Name;
        this.Gun_Dmg = gun_Info.Gun_Dmg;
        this.Gun_Ammo = gun_Info.Gun_Ammo;
        this.Gun_Full_Ammo = gun_Info.Gun_Full_Ammo;
    }
}
