using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFirstAniScript : MonoBehaviour
{
    [SerializeField]
    private GameObject rifleFirst;
    [SerializeField]
    private GameObject rifleNomal;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = rifleFirst.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        rifleFirst.SetActive(true);
        rifleNomal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkRifleAni();
    }

    void checkRifleAni()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RifleFirstDeploy")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            rifleFirst.SetActive(false);
            rifleNomal.SetActive(true);
        }
    }
}
