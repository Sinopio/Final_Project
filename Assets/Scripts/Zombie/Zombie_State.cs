using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_State : MonoBehaviour
{
    // 몹 매니저를 넣어줄 에정(최적화문제로 Find보다 지정이 좋을듯 하여)
    public GameObject Mob_Manager;
    // 몹 매니저에서 불러올 정보의 번호
    public int Mob_Number;
    private Mob_Manager_Script manager;

    // 몬스터 프리팝에 붙어 작동할 스크립트
    public float State_Hp;
    public float State_Dmg;
    public float State_Speed;

    // 몬스터의 상태를 애니메이션 스크립트에 넘겨줄 변수
    public bool State_isRun;
    public bool State_isAtk;
    public bool State_isDie;

    // 플레이어와 몬스터 사이의 거리
    public float distance;
    public GameObject Player;
    private void Start()
    {
        manager = Mob_Manager.GetComponent<Mob_Manager_Script>();
        State_Hp = manager.deck[Mob_Number].Mob_Hp;
        State_Dmg = manager.deck[Mob_Number].Mob_Dmg;
        State_Speed = manager.deck[Mob_Number].Mob_Speed;
        State_isRun = false;
        State_isAtk = false;
        State_isDie = false;
    }

    private void FixedUpdate()
    {
        distance_cal();
        //transform.LookAt(Player.transform);
    }

    void distance_cal()
    {
        distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        //Mathf.Abs(distance)
        if(Mathf.Abs(distance) < 3f)
        {
            State_isRun = false;
            State_isAtk = true;
        }
        else if(Mathf.Abs(distance) >= 3f && Mathf.Abs(distance) < 10)
        {
            State_isRun = true;
            State_isAtk = false;
        }
        else
        {
            State_isRun = false;
            State_isAtk = false;
        }
    }
}
