using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform Cam;

    private void Start()
    {
        Cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up);
    }
}
