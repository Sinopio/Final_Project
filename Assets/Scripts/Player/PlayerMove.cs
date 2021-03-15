using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    private float jumpRange;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float cameraRotationLimit;

    [SerializeField]
    private Camera myCamera;
    [SerializeField]
    private GameObject bulletPosition;
    [SerializeField]
    private GameObject gun;
    private float camerRotation;
    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        RotateCamera();
    }

    private void Move()
    {
        float X_move = Input.GetAxisRaw("Horizontal");
        float Z_move = Input.GetAxisRaw("Vertical");

        Vector3 Horizontla_move = transform.right * X_move;
        Vector3 Vertical_move = transform.forward * Z_move;
        Vector3 _move = (Horizontla_move + Vertical_move).normalized * moveSpeed;

        rig.MovePosition(transform.position + _move * Time.deltaTime);
    }

    private void Rotate()
    {
        float _rotate = Input.GetAxisRaw("Mouse X");
        Vector3 player_rotaion = new Vector3(0.0f, _rotate, 0.0f) * rotateSpeed;
        rig.MoveRotation(rig.rotation * Quaternion.Euler(player_rotaion));
    }

    
    private void RotateCamera()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * rotateSpeed;
        camerRotation -= _cameraRotationX;
        camerRotation = Mathf.Clamp(camerRotation, -cameraRotationLimit, cameraRotationLimit);

        myCamera.transform.localEulerAngles = new Vector3(camerRotation, 0f, 0f);
        bulletPosition.transform.localEulerAngles = new Vector3(camerRotation, 0f, 0f);
        //gun.transform.localEulerAngles = new Vector3(camerRotation, 0f, 0f);
    }
}
