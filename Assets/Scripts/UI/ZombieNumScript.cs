using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieNumScript : MonoBehaviour
{
    [SerializeField]
    private Text zombieNum;

    private void Update()
    {
        setZombieNumUI();
    }

    void setZombieNumUI()
    {
        zombieNum.text = ZombieState.zombieCount.ToString();
    }
}
