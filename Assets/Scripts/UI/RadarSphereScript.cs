using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSphereScript : MonoBehaviour
{
    [SerializeField]
    private GameObject radarSphere;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Radar")
        {
            radarSphere.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Radar")
        {
            radarSphere.SetActive(false);
        }
    }
}
