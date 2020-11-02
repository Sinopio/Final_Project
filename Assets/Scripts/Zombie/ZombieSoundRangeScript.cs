using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundRangeScript : MonoBehaviour
{
    public bool inSoundRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSoundRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inSoundRange = false;
        }
    }
}
