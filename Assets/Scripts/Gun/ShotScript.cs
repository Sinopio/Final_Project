using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField]
    private float delayTime;
    [SerializeField]
    private float shotDelay;
    [SerializeField]
    private GameObject manager;
    private GunManagerScript gunManager;

    //건매니져에서 정보 가져오기
    private void Start()
    {
        gunManager = manager.GetComponent<GunManagerScript>();
    }

    private void Update()
    {
        shot();
        delayTime += Time.deltaTime;
    }

    //총알풀에서 총알 가져오기
    void shot()
    {
        if (Input.GetMouseButton(0) && checkDelay())
        {
            BulletPoolScript.Instance.GetBullet();
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
