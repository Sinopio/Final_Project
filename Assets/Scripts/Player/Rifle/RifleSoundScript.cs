using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleSoundScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;
    [SerializeField]
    private float delayTime;

    [SerializeField]
    private AudioClip aimCenter;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip reload;
    [SerializeField]
    private float shotDelay;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;
        animator.SetBool("Move", true);
    }

    void OnDisable()
    {
        audio.clip = null;
    }

    private void Update()
    {
        RifleAni();
        delayTime += Time.deltaTime;
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

        if (Input.GetMouseButton(0) && checkDelay())
        {
            animator.SetBool("Shot", true);
            audio.clip = shot;
            audio.Play();
            animator.Play("RifleShot", -1, 0f);
        }

        if (Input.GetMouseButtonUp(0))
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

    bool checkDelay()
    {
        if (delayTime <= shotDelay)
        {
            return false;
        }
        else
        {
            delayTime = 0;
            return true;
        }
    }
}
