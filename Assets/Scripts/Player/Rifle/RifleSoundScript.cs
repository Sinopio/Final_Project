using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleSoundScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    [SerializeField]
    private AudioClip aimCenter;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip reload;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;
        animator.SetBool("Move", true);
    }

    private void Update()
    {
        RifleAni();
    }

    void RifleAni()
    {
        float X_move = Input.GetAxisRaw("Horizontal");
        float Z_move = Input.GetAxisRaw("Vertical");

        if (X_move != 0 || Z_move != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Shot", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            audio.clip = shot;
            audio.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RifleShot")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            animator.SetBool("Shot", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            audio.clip = reload;
            audio.Play();
            animator.SetBool("Reload", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RifleReload")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            animator.SetBool("Reload", false);
        }
    }
}
