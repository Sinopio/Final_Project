using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    PlayerMove playerMove;
    public static PlayerState Instance;

    public float Hp;
    public float MaxHp;

    public int medikitNum;
    [SerializeField]
    private float recoveryTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMove = gameObject.GetComponent<PlayerMove>();
        medikitNum = 0;
    }

    private void Update()
    {
        recoveryHp();
    }

    void recoveryHp()
    {
        if(Hp < 80 && Input.GetKey(KeyCode.Alpha4))
        {
            recoveryTime += Time.deltaTime;
            if(recoveryTime < 3.0f)
            {
                playerMove.moveSpeed = 2.0f;
            }
            else if (recoveryTime > 3.0f)
            {
                Hp = 80;
                playerMove.moveSpeed = 7.0f;
                recoveryTime = 0;
            }
        }
    }
}
