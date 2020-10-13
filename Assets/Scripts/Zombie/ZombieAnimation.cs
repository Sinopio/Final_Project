using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    // 애니메이션 사용을 위해 Animator 클래스 변수 선언
    private Animator animator;
    private ZombieState state;
    private ZombieSectorScript zombieSectorScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<ZombieState>();
        zombieSectorScript = GetComponent<ZombieSectorScript>();
    }

    private void Update()
    {
        UpdateZombieAni();
    }

    void UpdateZombieAni()
    {
        if (zombieSectorScript.isCollision)
        {
            switch (state.zombieState)
            {
                case 0:
                    animator.SetBool("Run", false);
                    animator.SetBool("Attack", false);
                    break;
                case 1:
                    animator.SetBool("Run", true);
                    animator.SetBool("Attack", false);
                    break;
                case 2:
                    animator.SetBool("Run", false);
                    animator.SetBool("Attack", true);
                    break;
            }
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
    }
}
