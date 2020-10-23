using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZombieSectorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float angleRange;
    [SerializeField]
    private float distance;
    public bool inSector = false;

    private Color blue = new Color(0f, 0f, 1f, 0.2f);
    private Color red = new Color(1f, 0f, 0f, 0.2f);
    private Vector3 direction;

    private float dotValue = 0f;

    private void Update()
    {
        checkSector();
    }

    void checkSector()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        direction = player.transform.position - transform.position;
        if (direction.magnitude < distance)
        {
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue)
            {
                //transform.LookAt(new Vector3(player.transform.position.x, -0.670f, player.transform.position.z));
                inSector = true;
            }

            else
            {
                inSector = false;
            }
                
        }
        else
        {
            inSector = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Handles.color = inSector ? red : blue;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, distance);
    }


}
