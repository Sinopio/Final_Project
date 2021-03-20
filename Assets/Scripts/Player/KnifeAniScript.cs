using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAniScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        meleeAni();
    }

    void meleeAni()
    {
        float X_move = Input.GetAxisRaw("Horizontal");
        float Z_move = Input.GetAxisRaw("Vertical");

        if (PlayerState.Instance.invenNum == 3 && Input.GetMouseButton(0))
        {
            animator.SetBool("Atk", true);
        }

        if (PlayerState.Instance.invenNum == 3)
        {
            if (X_move != 0 || Z_move != 0)
            {
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("KnifeAtk")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animator.SetBool("Atk", false);
        }
    }
}
