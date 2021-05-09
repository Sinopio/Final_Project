using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    private void Update()
    {
        //transform.rotation = Quaternion.Euler(0, 10, 0);
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.Self);
    }
}
