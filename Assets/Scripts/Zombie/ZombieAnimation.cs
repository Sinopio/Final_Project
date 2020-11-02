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
        putZombiePool();
    }

    void UpdateZombieAni()
    {

        switch (state.zombieState)
        {
            case 0: // Idle
                animator.SetBool("Run", false);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Slow", false);
                animator.SetBool("Fall_Back", false);
                break;
            case 1: // inRay
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Slow", false);
                break;
            case 2: // Atk
                animator.SetBool("Run", false);
                animator.SetBool("Attack", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Slow", false);
                break;
            case 3: // inSector
                animator.SetBool("Run", false);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                animator.SetBool("Slow", false);
                break;
            case 4: // inSoundSector
                animator.SetBool("Run", false);
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Slow", true);
                break;
            case 5: // Die
                animator.SetBool("Fall_Back", true);
                break;
        }
    }

    void putZombiePool()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Z_FallingBack")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            ZombiePoolScript.Instance.PutZombieObject(gameObject);
        }
    }
}
