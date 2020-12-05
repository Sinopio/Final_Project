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

    private void Update()
    {
        setOffMainUI();
    }

    void setOffMainUI()
    {
        if (uiRemainTime > 5.0f && !GeneratorScript.Instance.alert)
        {
            mainUI.SetActive(false);
        }
        else
        {
            uiRemainTime += Time.deltaTime;
        }
    }
}
