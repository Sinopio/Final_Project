using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSceneGoalScript : MonoBehaviour
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
    [SerializeField]
    private GameObject gameGoalUI;

    private double PSDistance;

    private void Update()
    {
        setOffMainUI();
        setDistance();
        setFalseAlert();
    }

    void setFalseAlert()
    {
        if(GeneratorScript.Instance.alert)
        {
            gameGoalUI.SetActive(false);
        }
    }

    void setOffMainUI()
    {
        if (uiRemainTime > 7.0f && !GeneratorScript.Instance.alert)
        {
            mainUI.SetActive(false);
            gameGoalUI.SetActive(true);
        }
        else
        {
            uiRemainTime += Time.deltaTime;
            gameGoalUI.SetActive(false);
        }
    }

    void setDistance()
    {
        PSDistance = Vector3.Distance(player.transform.position, safeHouse.transform.position);
        PSDistance = Math.Truncate(PSDistance * 10) / 10;
        distancd.text = PSDistance.ToString() + "m";
    }
}
