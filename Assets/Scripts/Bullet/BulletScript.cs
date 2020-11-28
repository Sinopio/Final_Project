using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bulletPosition;
    [SerializeField]
    private GameObject bulletLook;

    private float time;

    private void OnEnable()
    {
        gameObject.transform.position = bulletPosition.transform.position;
        gameObject.transform.LookAt(bulletLook.transform);
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * speed);
        if(time > 2f)
        {
            BulletPoolScript.Instance.PutBullet(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zombie")
        {
            BloodEffectPoolScript.Instance.setPosition(gameObject.transform.position);
            BloodEffectPoolScript.Instance.GetEffect();
            BulletPoolScript.Instance.PutBullet(gameObject);
        }
    }
}
