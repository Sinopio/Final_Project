using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    private AudioSource audio;

    [SerializeField]
    private AudioClip birth;
    [SerializeField]
    private AudioClip atk;
    [SerializeField]
    private AudioClip die;
    [SerializeField]
    private AudioClip angry;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;
    }
}
