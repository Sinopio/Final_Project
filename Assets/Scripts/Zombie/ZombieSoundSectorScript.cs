using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZombieSoundSectorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject destination;
    [SerializeField]
    private float distance;
    private float p_zDis;
    public bool inSoundSector = false;

    private Color yellow = new Color(1f, 1f, 1f, 0.2f);
    private Color green = new Color(0f, 1f, 0f, 0.2f);
    private void Update()
    {
        checkSoundSector();
    }

    void checkSoundSector()
    {
        p_zDis = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Mathf.Abs(p_zDis);
        if (p_zDis <= distance)
        {
            inSoundSector = true;
        }
        else
        {
            inSoundSector = false;
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = inSoundSector ? green : yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, distance);
    }
}
