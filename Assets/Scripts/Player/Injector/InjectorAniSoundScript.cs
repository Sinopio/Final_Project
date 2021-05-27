using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorAniSoundScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    [SerializeField]
    private float recoveryHp;
    [SerializeField]
    private AudioClip treatStart;
    [SerializeField]
    private AudioClip treatEnd;

    private float treatTime;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;
        applyInjectionUpgrade();
    }

    void OnDisable()
    {
        audio.clip = null;
    }

    private void Update()
    {
        TreatDelay();
        InjectorAni();
    }

    void applyInjectionUpgrade()
    {
        recoveryHp = 5 + UpgradeScript.Instance.deck[4].nowUpgrade1 * 5;
    }

    void InjectorAni()
    {
        audio.volume = UpgradeScript.Instance.soundValue;
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("TreatStart", true);
            audio.clip = treatStart;
            audio.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("InjectionStart")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            animator.SetBool("TreatStart", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("InjectionIdle") &&
            Input.GetMouseButton(0))
        {
            if(treatTime > 1.0f && PlayerState.Instance.Hp < PlayerState.Instance.MaxHp)
            {
                PlayerState.Instance.Hp += recoveryHp;
                PlayerState.Instance.medikitNum -= 5;
                treatTime = 0f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("TreatEnd", true);
            audio.clip = treatEnd;
            audio.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("InjectionEnd")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            //PlayerState.Instance.Hp += 20;
            animator.SetBool("TreatEnd", false);
        }
    }

    void TreatDelay()
    {
        if (treatTime <= 1.0f)
        { treatTime += Time.deltaTime; }        
    }
}
