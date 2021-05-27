using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelStage : MonoBehaviour
{
    [SerializeField]
    private GameObject nomalText;
    [SerializeField]
    private GameObject tutoText;
    [SerializeField]
    private GameObject stage1Text;
    [SerializeField]
    private GameObject stage2Text;

    [SerializeField]
    private GameObject sun;
    [SerializeField]
    private GameObject moon;

    [SerializeField]
    private Sprite onImage;
    [SerializeField]
    private Sprite offImage;

    [SerializeField]
    private Image tutoImage;
    [SerializeField]
    private Image stage1Image;
    [SerializeField]
    private Image stage2Image;

    [SerializeField]
    private Image tutoPosition;
    [SerializeField]
    private Image stage1Position;
    [SerializeField]
    private Image stage2Position;

    [SerializeField]
    private bool dayNight;
    [SerializeField]
    private int stageNum;

    private void Start()
    {
        dayNight = true;
        sun.SetActive(true);
        moon.SetActive(false);
        stageNum = 0;
        nomalText.SetActive(true);
        tutoText.SetActive(false);
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);
    }

    public void OnTutoImg()
    {
        tutoImage.sprite = onImage;
        tutoPosition.color = new Color(255, 0, 0, 1);

        stage1Image.sprite = offImage;
        stage1Position.color = new Color(0, 0, 0, 1);

        stage2Image.sprite = offImage;
        stage2Position.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(false);
        tutoText.SetActive(true);
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);

        stageNum = 1;
    }

    public void OffTutoImg()
    {
        tutoImage.sprite = offImage;
        tutoPosition.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(true);
        tutoText.SetActive(false);
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);

        stageNum = 0;
    }

    public void OnStage1Img()
    {
        stage1Image.sprite = onImage;
        stage1Position.color = new Color(255, 0, 0, 1);

        tutoImage.sprite = offImage;
        tutoPosition.color = new Color(0, 0, 0, 1);

        stage2Image.sprite = offImage;
        stage2Position.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(false);
        tutoText.SetActive(false);
        stage1Text.SetActive(true);
        stage2Text.SetActive(false);
        stageNum = 2;
    }

    public void OffStage1Img()
    {
        stage1Image.sprite = offImage;
        stage1Position.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(true);
        tutoText.SetActive(false);
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);
        stageNum = 0;
    }

    public void OnStage2Img()
    {
        stage2Image.sprite = onImage;
        stage2Position.color = new Color(255, 0, 0, 1);

        tutoImage.sprite = offImage;
        tutoPosition.color = new Color(0, 0, 0, 1);

        stage1Image.sprite = offImage;
        stage1Position.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(false);
        tutoText.SetActive(false);
        stage1Text.SetActive(false);
        stage2Text.SetActive(true);

        stageNum = 3;
    }

    public void OffStage2Img()
    {
        stage2Image.sprite = offImage;
        stage2Position.color = new Color(0, 0, 0, 1);

        nomalText.SetActive(true);
        tutoText.SetActive(false);
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);

        stageNum = 0;
    }

    public void SetTime()
    {
        if(dayNight)
        {
            sun.SetActive(false);
            moon.SetActive(true);
            dayNight = false;
        }

        else if (!dayNight)
        {
            sun.SetActive(true);
            moon.SetActive(false);
            dayNight = true;
        }
    }

    public void StartGame()
    {
        switch(stageNum)
        {
            //0은 아무것도 안 눌렀을때
            //1은 튜토리얼
            case 1:
                SceneManager.LoadScene(5);
                break;
            case 2:
                if(dayNight)
                {
                    SceneManager.LoadScene(1);
                }
                else if(!dayNight)
                {
                    SceneManager.LoadScene(2);
                }
                break;
            case 3:
                if (dayNight)
                {
                    SceneManager.LoadScene(3);
                }
                else if (!dayNight)
                {
                    SceneManager.LoadScene(4);
                }
                break;
        }
    }
}
