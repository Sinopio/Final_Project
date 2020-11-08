using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : MonoBehaviour
{
    // 몹 매니저를 넣어줄 에정(최적화문제로 Find보다 지정이 좋을듯 하여)
    [SerializeField]
    private GameObject mobManager;
    // 몹 매니저에서 불러올 정보의 번호
    [SerializeField]
    private int mobNumber;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject rayPosition;

    [SerializeField]
    private GameObject soundRange;
    [SerializeField]
    private GameObject smellRange;

    // 몬스터 프리팝에 붙어 작동할 스크립트
    public float stateHp;
    public float stateDmg;
    public float stateSpeed;
    // 몬스터의 상태를 애니메이션 스크립트에 넘겨줄 변수
    public int zombieState;
    // 몬스터의 갯수를 확인할 변수
    public static int zombieCount = 0;

    private float distance;
    private float p_zDis;

    private MobManagerScript manager;
    private ZombieRayScript zombieRayScript;
    private ZombieSoundRangeScript zombieSoundRange;
    private ZombieSmellRangeScript zombieSmellRange;
    /*private ZombieSectorScript zombieSectorScript;
    private ZombieSoundSectorScript zombieSoundSectorScript;*/

    private void OnEnable()
    {
        zombieState = 0;
    }

    private void OnDisable()
    {
        zombieCount++;
        Debug.Log("소멸 >> " + zombieCount);
        manager = mobManager.GetComponent<MobManagerScript>();
        stateHp = manager.deck[mobNumber].mobHp;
        stateDmg = manager.deck[mobNumber].mobDmg;
        stateSpeed = manager.deck[mobNumber].mobSpeed;
        zombieState = 0;
    }

    private void Start()
    {
        zombieRayScript = rayPosition.GetComponent<ZombieRayScript>();
        /*zombieSectorScript = GetComponent<ZombieSectorScript>();
         zombieSoundSectorScript = GetComponent<ZombieSoundSectorScript>();*/
        zombieSoundRange = soundRange.GetComponent<ZombieSoundRangeScript>();
        zombieSmellRange = smellRange.GetComponent<ZombieSmellRangeScript>();

        manager = mobManager.GetComponent<MobManagerScript>();
        stateHp = manager.deck[mobNumber].mobHp;
        stateDmg = manager.deck[mobNumber].mobDmg;
        stateSpeed = manager.deck[mobNumber].mobSpeed;
        zombieState = 0;
    }

    private void FixedUpdate()
    {
        setState();
    }

    void setState()
    {
        p_zDis = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (stateHp <= 0)
        {
            zombieState = 5;
        }
        else if (!zombieRayScript.inSight && !zombieSmellRange.inSmellRange && !zombieSoundRange.inSoundRange)
        {
            zombieState = 0;
        }
        else if (zombieRayScript.inSight && p_zDis >= 2f)
        {
            zombieState = 1;
        }
        else if (zombieRayScript.inSight && p_zDis < 2f)
        {
            zombieState = 2;
        }
        else if (!zombieRayScript.inSight && zombieSmellRange.inSmellRange)
        {
            zombieState = 3;
        }
        else if (!zombieRayScript.inSight && !zombieSmellRange.inSmellRange && zombieSoundRange.inSoundRange)
        {
            zombieState = 4;
        }
    }
}
