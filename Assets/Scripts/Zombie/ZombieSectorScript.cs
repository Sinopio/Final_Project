using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZombieSectorScript : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private float angleRange;
    [SerializeField]
    private float distance;
    public bool isCollision = false;

    Color blue = new Color(0f, 0f, 1f, 0.2f);
    Color red = new Color(1f, 0f, 0f, 0.2f);
    Vector3 direction;

    float dotValue = 0f;

    private void Update()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        direction = player.transform.position - transform.position;
        if (direction.magnitude < distance)
        {
            if (Vector3.Dot(direction.normalized, transform.forward) > dotValue)
                isCollision = true;
            else
                isCollision = false;
        }
        else
            isCollision = false;
    }

    private void OnDrawGizmos()
    {
        Handles.color = isCollision ? red : blue;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, distance);
    }
}
