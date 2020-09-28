using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Animation : MonoBehaviour
{
    // 애니메이션 사용을 위해 Animator 클래스 변수 선언
    Animator animator;
    Zombie_State State;

    private float Hp;
    private bool isRun;
    private bool isAtk;
    private bool isDie;

    private void Start()
    {
        State = GetComponent<Zombie_State>();
        animator = GetComponent<Animator>();
        isRun = false;
        isAtk = false;
        isDie = false;
    }

    private void Update()
    {
        Run_Ani();
        Atk_Ani();
        Die_Ani();
    }

    void Run_Ani()
    {
        if(State.State_isRun)
        {
            animator.SetBool("Run", true);
        }
        if (!State.State_isRun)
        {
            animator.SetBool("Run", false);
        }
    }

    void Atk_Ani()
    {
        if(State.State_isAtk)
        {
            animator.SetBool("Attack", true);
        }
        if (!State.State_isAtk)
        {
            animator.SetBool("Attack", false);
        }
    }

    void Die_Ani()
    {
        if (State.State_isDie)
        {
            animator.SetBool("Fall_Back", true);
        }
    }
}
