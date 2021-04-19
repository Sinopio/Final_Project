using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContactScript : MonoBehaviour
{
    private bool inInstalling;
    public bool contact;

    private Renderer rend;

    [SerializeField]
    private Material red;
    [SerializeField]
    private Material nomal;

    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        inInstalling = false;
    }

    private void Update()
    {
        if (!inInstalling)
        {
            rend.material = nomal;
        }

        if(Input.GetMouseButtonDown(0))
        {
            inInstalling = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Map")
        {
            contact = true;
            inInstalling = true;
            rend.material = red;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        contact = false;
        inInstalling = false;
    }
}
