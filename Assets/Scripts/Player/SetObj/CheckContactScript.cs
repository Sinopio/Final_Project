using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContactScript : MonoBehaviour
{
    public bool contact;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Map")
        {
            contact = true;
            Debug.Log(contact + col.tag + "충돌 시작");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag + "충돌 중");
    }

    private void OnTriggerExit(Collider col)
    {
        contact = false;
        Debug.Log(contact + "충돌 끝");
        /*
        if (col.tag == "Map")
        {
            contact = false;
            Debug.Log(contact + "충돌 끝");
        }
        */
    }
}
