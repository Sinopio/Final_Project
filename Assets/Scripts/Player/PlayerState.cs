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
    public int money;
    public float speed;


    private float recoveryTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        money = 0;
        playerMove = gameObject.GetComponent<PlayerMove>();
        medikitNum = 100;
        invenNum = 3;
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
                speed = 2.0f;
            }
            else if (recoveryTime > 3.0f)
            {
                Hp = 80;
                speed = 7.0f;
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
        else if (Input.GetKeyDown(KeyCode.G))
        {
            invenNum = 10;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            invenNum = 11;
        }
    }
}
