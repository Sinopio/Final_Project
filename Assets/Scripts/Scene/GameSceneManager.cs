using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultUI;
    [SerializeField]
    private Text deadZombieNum;
    [SerializeField]
    private Text getMoney;

    private void Awake()
    {
        resultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerState.Instance.Hp <= 0)
        {
            resultUI.SetActive(true);
            setResult();
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }        
    }

    void setResult()
    {
        deadZombieNum.text = ZombiePoolScript.Instance.deadNum.ToString();
        getMoney.text = PlayerState.Instance.money.ToString();
        UpgradeScript.Instance.money += PlayerState.Instance.money;
    }   

    public void ToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStartStage1()
    {
        SceneManager.LoadScene(1);
    }

    public void ReStartStage2()
    {
        SceneManager.LoadScene(3);
    }

    public void ReStartStage1Hard()
    {
        SceneManager.LoadScene(2);
    }

    public void ReStartStage2Hard()
    {
        SceneManager.LoadScene(4);
    }
}
