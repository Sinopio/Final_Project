using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject resultUI;

    //스테이지 성공실패 텍스트
    [SerializeField]
    private Text resultText;
    //처치한 좀비 수
    [SerializeField]
    private Text deadZombieNum;
    //획득한 돈
    [SerializeField]
    private Text getMoney;
    //목표 달성 보상
    [SerializeField]
    private Text goalReward;

    private int stagereward;

    //지원까지 남은 시간 표시
    [SerializeField]
    private Text questNum;
    //목표시간
    [SerializeField]
    private float stageGoal;
    private float nowtime;
    [SerializeField]
    private GameObject questUI;
    [SerializeField]
    private GameObject cursurManager;

    private void Awake()
    {
        resultUI.SetActive(false);
    }

    private void Start()
    {
        questNum.text = stageGoal.ToString();
    }

    private void Update()
    {
        if (PlayerState.Instance.Hp <= 0)
        {
            Time.timeScale = 0;
            FailStage();
        }
        SetQuest();
        nowtime += Time.deltaTime;
    }

    void SetQuest()
    {
        if(stageGoal - nowtime > 0)
        {
            questNum.text = (stageGoal - nowtime).ToString("N1");
        }

        if (stageGoal - nowtime <= 0)
        {
            questUI.SetActive(false);
            resultUI.SetActive(true);

            setResult();
        }
    }

    void FailStage()
    {
        PlayerState.Instance.isUION = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        resultText.text = "작전 실패";

        questUI.SetActive(false);
        cursurManager.SetActive(false);
        resultUI.SetActive(true);

        deadZombieNum.text = ZombiePoolScript.Instance.deadNum.ToString();
        getMoney.text = PlayerState.Instance.money.ToString();
        stagereward = 0;
        goalReward.text = "0";
    }

    void setResult()
    {
        PlayerState.Instance.isUION = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        resultText.text = "작전 성공";

        questUI.SetActive(false);
        cursurManager.SetActive(false);
        resultUI.SetActive(true);

        deadZombieNum.text = ZombiePoolScript.Instance.deadNum.ToString();
        getMoney.text = PlayerState.Instance.money.ToString();
        stagereward = 800;
        goalReward.text = stagereward.ToString();
    }

    void uploadMoney()
    {
        UpgradeScript.Instance.money += PlayerState.Instance.money;
        UpgradeScript.Instance.money += stagereward;
    }

    public void ToMainScene()
    {
        uploadMoney();
        SceneManager.LoadScene(0);
    }

    public void ReStartStage1Hard()
    {
        SceneManager.LoadScene(2);
    }
}
