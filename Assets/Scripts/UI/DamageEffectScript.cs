using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dmgEffect;
    [SerializeField]
    private float fadeSpeed;

    private Image rend;
    [SerializeField]
    private bool onhit;
    [SerializeField]
    private float colorAlpha;

    private AudioSource audio;

    [SerializeField]
    private AudioClip hit;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        colorAlpha = 1;
        rend = dmgEffect.GetComponent<Image>();
        rend.color = new Color(255, 255, 255, 0);
        onhit = false;
    }

    private void Update()
    {        
        fadeOut();
    }

    void fadeOut()
    {
        if(onhit)
        {
            
            colorAlpha -= fadeSpeed * Time.deltaTime;
            rend.color = new Color(255, 255, 255, colorAlpha);
        }

        if(rend.color.a < 0.5)
        {
            rend.color = new Color(255, 255, 255, 0);
            colorAlpha = 1.0f;
            onhit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZombieAtk")
        {
            audio.clip = hit;
            audio.Play();
            PlayerState.Instance.Hp -= 5;
            rend.color = new Color(255, 255, 255, 1);
            onhit = true;
        }
    }
}
