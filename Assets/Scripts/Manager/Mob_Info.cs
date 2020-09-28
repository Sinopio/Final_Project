using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mob_Info
{
    // 몹 이름
    public string Mob_Name;
    // 몹 Hp
    public float Mob_Hp;
    // 몹 데미지
    public float Mob_Dmg;
    // 몹 스피드
    public float Mob_Speed;

    public Mob_Info(Mob_Info mob_Info)
    {
        this.Mob_Name = mob_Info.Mob_Name;
        this.Mob_Hp = mob_Info.Mob_Hp;
        this.Mob_Dmg = mob_Info.Mob_Dmg;
        this.Mob_Speed = mob_Info.Mob_Speed;
    }
}
