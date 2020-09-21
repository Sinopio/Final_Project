using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    // 이동속도
    public float move_speed;
    // 점프범위
    public float jump_range;
    // 회전속도
    public float rotate_speed;
    // 카메라 상하회전 범위
    public float camera_rotation_limit;

    public Camera my_camera;
    private float camer_rotation;
    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
        Camera_Rotation();
    }

    private void Move()
    {
        float X_move = Input.GetAxisRaw("Horizontal");
        float Z_move = Input.GetAxisRaw("Vertical");

        Vector3 Horizontla_move = transform.right * X_move;
        Vector3 Vertical_move = transform.forward * Z_move;
        Vector3 _move = (Horizontla_move + Vertical_move).normalized * move_speed;

        rig.MovePosition(transform.position + _move * Time.deltaTime);
    }

    private void Rotation()
    {
        float _rotate = Input.GetAxisRaw("Mouse X");
        Vector3 player_rotaion = new Vector3(0.0f, _rotate, 0.0f) * rotate_speed;
        rig.MoveRotation(rig.rotation * Quaternion.Euler(player_rotaion));
    }

    private void Camera_Rotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * rotate_speed;
        camer_rotation -= _cameraRotationX;
        camer_rotation = Mathf.Clamp(camer_rotation, -camera_rotation_limit, camera_rotation_limit);

        my_camera.transform.localEulerAngles = new Vector3(camer_rotation, 0f, 0f);
    }

}
