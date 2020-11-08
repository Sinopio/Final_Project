using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtkScript : MonoBehaviour
{
    [SerializeField]
    private GameObject atkRange;
    private Animator animator;

    private void OnEnable()
    {
        atkRange.SetActive(false);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        setAtkRange();
    }

    void setAtkRange()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f)
        {
            atkRange.SetActive(true);
        }

        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            atkRange.SetActive(false);
        }
    }

}
