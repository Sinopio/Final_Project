using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAniSoundScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    [SerializeField]
    private AudioClip loadGrenade;
    [SerializeField]
    private AudioClip throwGrenade;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>();
    }

    void OnDisable()
    {
        audio.clip = null;

    }
    private void Update()
    {
        ThrowGrenade();
    }

    void ThrowGrenade()
    {
        audio.volume = UpgradeScript.Instance.soundValue;
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.grenadeNum > 0)
        {
            animator.SetBool("Load", true);
            audio.clip = loadGrenade;
            audio.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GrenadeThrowStart")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            animator.SetBool("Load", false);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Throw", true);
            audio.clip = throwGrenade;
            audio.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GrenadeThrow")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            animator.SetBool("Throw", false);
        }

        if (PlayerState.Instance.grenadeNum > 0)
        {
            animator.SetBool("Reload", true);
        }
    }
}
