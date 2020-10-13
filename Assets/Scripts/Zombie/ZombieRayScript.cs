using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRayScript : MonoBehaviour
{
    public bool onSight;

    private ZombieSectorScript zombieSectorScript;
    private RaycastHit[] raycastHits;
    [SerializeField]
    private float rayLength;
    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        zombieSectorScript = parent.GetComponent<ZombieSectorScript>();
    }
    private void Update()
    {
        checkObstacle();
    }

    void checkObstacle()
    {
        if(zombieSectorScript.isCollision)
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            raycastHits = Physics.RaycastAll(transform.position, transform.forward, rayLength);

            for (int i = 0; i < raycastHits.Length; i++)
            {
                //Debug.Log(raycastHits[i].collider.name + i);
                if (raycastHits[i].collider.tag == "Player")
                {
                    if (i == 0)
                    {
                        //Debug.Log(raycastHits[i].collider.name + ": onSight " + i);
                        onSight = true;
                    }

                    else if (i >= 2)
                    {
                        //Debug.Log(raycastHits[i].collider.name + ": Obstacle " + i);
                        onSight = false;
                    }
                }
            }
        }

        else if (!zombieSectorScript.isCollision)
        {
            onSight = false;
        }
    }
}

// private RaycastHit raycastHit;
/*
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, rayLength))
        {
            Debug.Log(raycastHit.collider.name);
        }
*/
