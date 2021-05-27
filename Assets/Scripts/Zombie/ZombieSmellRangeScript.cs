using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSmellRangeScript : MonoBehaviour
{
    public bool inSmellRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Generator")
        {
            inSmellRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Generator")
        {
            inSmellRange = false;
        }
    }
}
