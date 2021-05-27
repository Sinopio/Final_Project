using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setEffectSound : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        setBgm();
    }

    void setBgm()
    {
        audio.volume = UpgradeScript.Instance.soundValue;
    }
}
