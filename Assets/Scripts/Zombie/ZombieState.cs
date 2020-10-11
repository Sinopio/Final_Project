using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : MonoBehaviour
{
    // 몹 매니저를 넣어줄 에정(최적화문제로 Find보다 지정이 좋을듯 하여)
    public GameObject mobManager;
    // 몹 매니저에서 불러올 정보의 번호
    public int mobNumber;
    private MobManagerScript manager;

    // 몬스터 프리팝에 붙어 작동할 스크립트
    public float stateHp;
    public float stateDmg;
    public float stateSpeed;

    // 몬스터의 상태를 애니메이션 스크립트에 넘겨줄 변수
    public int zombieState;

    // 플레이어와 몬스터 사이의 거리
    public float distance;
    public GameObject player;
    private void Start()
    {
        manager = mobManager.GetComponent<MobManagerScript>();
        stateHp = manager.deck[mobNumber].mobHp;
        stateDmg = manager.deck[mobNumber].mobDmg;
        stateSpeed = manager.deck[mobNumber].mobSpeed;
        zombieState = 0;
    }

    private void FixedUpdate()
    {
        distance_cal();
    }

    void distance_cal()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        //Mathf.Abs(distance)
        if(Mathf.Abs(distance) < 3f)
        {
            zombieState = 2;
        }
        else if(Mathf.Abs(distance) >= 3f && Mathf.Abs(distance) < 10)
        {
            zombieState = 1;
        }
        else
        {
            zombieState = 0;
        }
    }
}
