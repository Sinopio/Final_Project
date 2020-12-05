using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHouseRadarScript : MonoBehaviour
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
        setPositionInRadar();
        distance = Vector3.Distance(gameObject.transform.parent.transform.position, player.transform.position);
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
}
