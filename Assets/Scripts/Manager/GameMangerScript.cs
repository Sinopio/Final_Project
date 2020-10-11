using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMangerScript : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
