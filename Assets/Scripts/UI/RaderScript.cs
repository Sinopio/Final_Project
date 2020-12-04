using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float radius;
    private Vector3 position;

    [SerializeField]
    private float angle;
    [SerializeField]
    private float distance;


    private void Update()
    {
        //gameObject.transform.LookAt(playerPosition.transform);
        //position.x = player.transform.position.x + (radius * Mathf.Cos(getAngle()));
        //position.z = player.transform.position.z + (radius * Mathf.Sin(getAngle()));
        angle = getAngle();
        distance = Vector3.Distance(gameObject.transform.parent.transform.position, player.transform.position);
        setPositionInRadar();
    }


    void setPositionInRadar()
    {
        gameObject.transform.LookAt(gameObject.transform.parent);
        if (distance > radius)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 1000);
            gameObject.transform.position = (transform.position - player.transform.position).normalized * radius +
               player.transform.position;
        }
        else
        {
            gameObject.transform.position = gameObject.transform.parent.transform.position;
        }

    }

    float getAngle()
    {

        Vector3 vector = player.transform.position - gameObject.transform.parent.transform.position;

        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        /*
        dot = Vector3.Dot(playerPosition.transform.position, gameObject.transform.parent.transform.position);
        angle = Mathf.Acos(dot);

        return angle * Mathf.Rad2Deg;
        */
    }
}
