using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGoalScript : MonoBehaviour
{
    private float uiRemainTime;
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private Text distancd;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject safeHouse;
    private double PSDistance;

    private void Update()
    {
        setOffMainUI();
        setDistance();
    }

    void setOffMainUI()
    {
        if (uiRemainTime > 7.0f)
        {
            mainUI.SetActive(false);
        }
        else
        {
            uiRemainTime += Time.deltaTime;
        }
    }

    void setDistance()
    {
        PSDistance = Vector3.Distance(player.transform.position, safeHouse.transform.position);
        PSDistance = Math.Truncate(PSDistance * 10) / 10;
        distancd.text = PSDistance.ToString() + "m";
    }
}
