using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRayScript : MonoBehaviour
{
    public bool inSight;

    private ZombieSectorScript zombieSectorScript;
   
    private RaycastHit raycastHit;
    [SerializeField]
    private float rayLength;
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject player;

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
        if (zombieSectorScript.inSector)
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z));
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, rayLength))
            {
                Debug.Log(raycastHit.collider.name);
                if(raycastHit.collider.tag == "Player")
                {
                    inSight = true;
                }
                else
                {
                    inSight = false;
                }
            }
        }
    }
}

// private RaycastHit[] raycastHits;
/*
if(zombieSectorScript.inSector)
{
    Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
    raycastHits = Physics.RaycastAll(transform.position, transform.forward, rayLength);
    //transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
    transform.LookAt(player.transform);
    for (int i = 0; i < raycastHits.Length; i++)
    {
        //Debug.Log(raycastHits[i].collider.name + i);
        if (raycastHits[i].collider.tag == "Player")
        {
            if (i == 0)
            {
                onSight = true;
            }

            else if (i >= 2)
            {
                onSight = false;
            }
        }
    }
}

else if (!zombieSectorScript.inSector)
{
    onSight = false;
}*/
