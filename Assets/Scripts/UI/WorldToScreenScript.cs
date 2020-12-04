using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScreenScript : MonoBehaviour
{
    public Transform target = null;

    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position);
    }


}
