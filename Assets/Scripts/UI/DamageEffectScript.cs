using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dmgEffect;
    [SerializeField]
    private bool onhit;

    private float effectTime;

    private void Update()
    {
        if(onhit && effectTime < 1.5f)
        {
            effectTime += Time.deltaTime;
        }

        if(effectTime > 1.5f)
        {
            dmgEffect.SetActive(false);
            onhit = false;
            effectTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZombieAtk")
        {
            dmgEffect.SetActive(true);
            onhit = true;
        }
    }
    /*
    [SerializeField]
    private GameObject dmgEffect;
    [SerializeField]
    private float fadeSpeed;

    private Color rend;
    [SerializeField]
    private bool onhit;

    private void Start()
    {
        rend = dmgEffect.GetComponent<Image>().color;
        rend.a = 0;
        onhit = false;
    }
    private void Update()
    {
        Debug.Log(rend.a);
        fadeOut();
    }

    void fadeOut()
    {
        if(onhit && rend.a > 125)
        {
            rend.a -= fadeSpeed * Time.deltaTime;
            Debug.Log("fadeout");
        }

        if(onhit && rend.a <= 125)
        {
            onhit = false;
            Debug.Log("fadeout");
            rend.a = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "ZombieAtk")
        {
            Debug.Log("cndefdf");
            rend.a = 255;
            onhit = true;
        }
    }*/
}
