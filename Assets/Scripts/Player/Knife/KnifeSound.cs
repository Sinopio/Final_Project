using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSound : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField]
    private AudioClip firstSound;
    [SerializeField]
    private AudioClip atkSound;
    private KnifeAniScript checkAni;

    // Start is called before the first frame update
    void Start()
    {
        checkAni = gameObject.GetComponent<KnifeAniScript>();
        audio = this.gameObject.AddComponent<AudioSource>();
        audio.loop = false;
    }

    void OnDisable()
    {
        audio.clip = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3) && PlayerState.Instance.invenNum != 3)
        {
            audio.clip = firstSound;
            audio.Play();
        }

        if (PlayerState.Instance.invenNum == 3 && Input.GetMouseButton(0) && !checkAni.checkAtk)
        {
            audio.clip = atkSound;
            audio.Play();
        }
    }
}
