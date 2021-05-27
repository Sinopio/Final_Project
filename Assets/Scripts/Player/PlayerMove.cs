using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float jumpRange;
    public float rotateSpeed;
    [SerializeField]
    private float cameraRotationLimit;

    [SerializeField]
    private Camera myCamera;
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
        Vector3 _move = (Horizontla_move + Vertical_move).normalized * 
            PlayerState.Instance.speed;

        rig.MovePosition(transform.position + _move * Time.deltaTime);
    }

    private void Rotate()
    {
        float _rotate = Input.GetAxisRaw("Mouse X");
        Vector3 player_rotaion = new Vector3(0.0f, _rotate, 0.0f) * rotateSpeed
            * UpgradeScript.Instance.rotateValue;
        rig.MoveRotation(rig.rotation * Quaternion.Euler(player_rotaion));
    }

    
    private void RotateCamera()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * rotateSpeed * UpgradeScript.Instance.rotateValue;
        camerRotation -= _cameraRotationX;
        camerRotation = Mathf.Clamp(camerRotation, -cameraRotationLimit, cameraRotationLimit);

        myCamera.transform.localEulerAngles = new Vector3(camerRotation, 0f, 0f);
    }
}
