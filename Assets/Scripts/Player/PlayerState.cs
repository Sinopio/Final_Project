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
    public int grenadeNum;
    public int invenNum;


    private float recoveryTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMove = gameObject.GetComponent<PlayerMove>();
        medikitNum = 0;
        invenNum = 0;
    }

    private void Update()
    {
        recoveryHp();
        setInven();
    }

    void recoveryHp()
    {
        if(Hp < 80 && Input.GetKey(KeyCode.E) && invenNum == 4)
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
                medikitNum--;
                recoveryTime = 0;
            }
        }
    }

    void setInven()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            invenNum = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            invenNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            invenNum = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && grenadeNum > 0)
        {
            invenNum = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && medikitNum > 0)
        {
            invenNum = 5;
        }
    }
}
