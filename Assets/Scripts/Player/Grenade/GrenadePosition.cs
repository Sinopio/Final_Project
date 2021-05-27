using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePosition : MonoBehaviour
{

    private Rigidbody rig;
    public float rotateSpeed;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float _rotate = Input.GetAxisRaw("Mouse X");
        Vector3 player_rotaion = new Vector3(0.0f, _rotate, 0.0f) * rotateSpeed;
        rig.MoveRotation(rig.rotation * Quaternion.Euler(player_rotaion));
    }
}
