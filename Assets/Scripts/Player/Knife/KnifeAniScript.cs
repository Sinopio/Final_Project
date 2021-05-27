using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAniScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject atkRange;
    public bool checkAtk;


    private void Start()
    {
        checkAtk = false;
        atkRange.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(PlayerState.Instance.isUION == false)
        {
            meleeAni();
            callAtkRange();
        }
    }

    void meleeAni()
    {
        float X_move = Input.GetAxisRaw("Horizontal");
        float Z_move = Input.GetAxisRaw("Vertical");

        if (PlayerState.Instance.invenNum == 3 && Input.GetMouseButton(0))
        {
            checkAtk = true;
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

    void callAtkRange()
    {
        if (PlayerState.Instance.invenNum == 3 && Input.GetMouseButtonDown(0))
        {
            atkRange.SetActive(true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("KnifeAtk")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            checkAtk = false;
            atkRange.SetActive(false);
        }
    }
}
