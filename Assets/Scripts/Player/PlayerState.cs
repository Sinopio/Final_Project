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
        applyPlayerUpgrade();
    }


    void applyPlayerUpgrade()
    {
        Hp += UpgradeScript.Instance.deck[5].nowUpgrade1 * 20;
        MaxHp += UpgradeScript.Instance.deck[5].nowUpgrade1 * 20;
        speed += UpgradeScript.Instance.deck[5].nowUpgrade2 * 1;
    }

    private void Update()
    {
        setInven();
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
