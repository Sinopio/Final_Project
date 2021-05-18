using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGoal : MonoBehaviour
{
    [SerializeField]
    private Text questNum;
    [SerializeField]
    private Text goalNum;
    [SerializeField]
    private int stageGoal;
    [SerializeField]
    private GameObject questUI;
    [SerializeField]
    private GameObject resultUI;

    private void Start()
    {
        goalNum.text = stageGoal.ToString();
    }

    private void Update()
    {
        SetQuest();    
    }

    void SetQuest()
    {
        questNum.text = ZombiePoolScript.Instance.deadNum.ToString();
        if(ZombiePoolScript.Instance.deadNum >= stageGoal)
        {
            questUI.SetActive(false);
            resultUI.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
