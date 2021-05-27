using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage3 : MonoBehaviour
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

    //현재 획득 개수
    [SerializeField]
    private Text questNum;
    //목표 개수
    [SerializeField]
    private Text goalNum;
    //스테이지 목표
    [SerializeField]
    private int stageGoal;

    //시작했을때
    [SerializeField]
    private GameObject stage3_text_1;
    //보급에 닿았을때
    [SerializeField]
    private GameObject stage3_text_2;
    //보급을 먹었을때
    [SerializeField]
    private GameObject stage3_text_3;

    //획득 시간 UI
    [SerializeField]
    private GameObject itemBarUi;
    //획득 시간 게이지UI
    [SerializeField]
    private Image suppliesBar;

    [SerializeField]
    private GameObject questUI;
    [SerializeField]
    private GameObject cursurManager;

    //보급을 획득헀는지
    private bool isTakeBullet;
    private float suppliesRunTime;

    private void Awake()
    {
        resultUI.SetActive(false);
    }

    private void Start()
    {
        isTakeBullet = false;
        goalNum.text = stageGoal.ToString();
        stage3_text_1.SetActive(true);
        stage3_text_2.SetActive(false);
        stage3_text_3.SetActive(false);
        itemBarUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerState.Instance.Hp <= 0)
        {
            Time.timeScale = 0;
            FailStage();
        }
        SetQuestText();
        getSupplies();
        onQuestArea();
    }

    void SetQuestText()
    {
        if (PlayerState.Instance.stage3_supplies == false && isTakeBullet == false)
        {
            stage3_text_1.SetActive(true);
            stage3_text_2.SetActive(false);
            stage3_text_3.SetActive(false);
        }

        if (PlayerState.Instance.stage3_supplies == true && isTakeBullet == false)
        {
            stage3_text_1.SetActive(false);
            stage3_text_2.SetActive(true);
            stage3_text_3.SetActive(false);
        }

        if (isTakeBullet == true)
        {
            stage3_text_1.SetActive(false);
            stage3_text_2.SetActive(false);
            stage3_text_3.SetActive(true);
        }
    }

    void getSupplies()
    {
        if (PlayerState.Instance.stage3_supplies && Input.GetKey(KeyCode.F) && !isTakeBullet)
        {
            itemBarUi.SetActive(true);
            suppliesRunTime += Time.deltaTime;
            if (suppliesRunTime < 10)
            {
                suppliesBar.fillAmount = suppliesRunTime / 10.0f;

            }
            else if (suppliesRunTime >= 3)
            {
                isTakeBullet = true;
                questNum.text = "1";
                itemBarUi.SetActive(false);
                //suppliesRunTime = 0;
            }
        }

        if (!isTakeBullet && Input.GetKeyUp(KeyCode.E))
        {
            itemBarUi.SetActive(false);
            suppliesRunTime = 0;
        }
    }

    //퀘스트 지역에 도착
    void onQuestArea()
    {
        //퀘스트 달성
        if (isTakeBullet && PlayerState.Instance.stage3_questArea)
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

    public void ReStartStage2()
    {
        SceneManager.LoadScene(3);
    }
}
