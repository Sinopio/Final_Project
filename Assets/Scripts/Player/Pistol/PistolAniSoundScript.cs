using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAniSoundScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;
    private GunManagerScript gunManager;
    private bool canReload;

    [SerializeField]
    private GameObject manager;
    [SerializeField]
    private AudioClip firstTime;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip reload;

    void Start()
    {
        gunManager = manager.GetComponent<GunManagerScript>();
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;
        canReload = false;
        animator.SetBool("Move", true);
    }

    void OnDisable()
    {
        audio.clip = null;
    }

    private void Update()
    {
        if (PlayerState.Instance.isUION == false)
        {
            PistolAni();
            ReloadPistol();
            ShotPistol();
        }   
    }

    void PistolAni()
    {
        audio.volume = UpgradeScript.Instance.soundValue;
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

        if (Input.GetMouseButtonDown(0) && gunManager.deck[1].gunAmmo > 0)
        {
            animator.SetBool("Shot", true);
            audio.clip = shot;
            audio.Play();
            animator.Play("PistolShot", -1, 0f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            audio.clip = reload;
            audio.Play();
            animator.SetBool("Reload", true);
            canReload = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PistolReload")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            animator.SetBool("Reload", false);
        }
    }

    void ReloadPistol()
    {
        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RifleReload")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            canReload = true;
        }
        */
        if (canReload)
        {
            if (gunManager.deck[1].gunFullAmmo >= gunManager.deck[1].ammoNum)
            {
                gunManager.deck[1].gunFullAmmo += gunManager.deck[1].gunAmmo;
                gunManager.deck[1].gunAmmo = 0;
                gunManager.deck[1].gunAmmo += gunManager.deck[1].ammoNum;
                gunManager.deck[1].gunFullAmmo -= gunManager.deck[1].ammoNum;
                canReload = false;
            }

            if (gunManager.deck[1].gunFullAmmo < gunManager.deck[1].ammoNum)
            {
                gunManager.deck[1].gunAmmo += gunManager.deck[1].gunFullAmmo;
                gunManager.deck[1].gunFullAmmo = 0;
                canReload = false;
            }

            if (gunManager.deck[1].gunFullAmmo == 0)
            {
                canReload = false;
            }
        }

    }

    //총알풀에서 총알 가져오기
    void ShotPistol()
    {
        if (Input.GetMouseButtonDown(0) && gunManager.deck[1].gunAmmo > 0)
        {
            gunManager.deck[1].gunAmmo--;
            BulletPoolScript.Instance.GetBullet();
        }
    }
}
