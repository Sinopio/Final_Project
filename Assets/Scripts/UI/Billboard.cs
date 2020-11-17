using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform Cam;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject E_keyUI;
    [SerializeField]
    private float Distance;
    private void Start()
    {
        Cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            E_keyUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            E_keyUI.SetActive(false);
        }
    }
}
