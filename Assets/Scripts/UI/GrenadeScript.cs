using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeScript : MonoBehaviour
{
    [SerializeField]
    private Text grenadeNum;

    // Update is called once per frame
    void Update()
    {
        setGrenadeNum();
    }

    void setGrenadeNum()
    {
        grenadeNum.text = PlayerState.Instance.grenadeNum.ToString();
    }
}
