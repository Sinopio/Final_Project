using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscUI : MonoBehaviour
{
    [SerializeField]
    private bool isEscOn;
    [SerializeField]
    private GameObject escUi;
    [SerializeField]
    private GameObject optionUi;
    [SerializeField]
    private GameObject toMainUi;
    [SerializeField]
    private GameObject toExitUi;
    [SerializeField]
    private GameObject cursurManager;


    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider rotateSlider;

    private void Start()
    {
        isEscOn = false;
        escUi.SetActive(false);
    }

    private void Update()
    {
        setEscUI();
    }

    //esc 눌렀을때 켜지기
    //다시 esc누르면 꺼지기
    void setEscUI()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!isEscOn)
            {
                PlayerState.Instance.isUION = true;
                cursurManager.SetActive(false);
                escUi.SetActive(true);
                Time.timeScale = 0;
                isEscOn = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    //게임으로 누르면 꺼지기
    public void BackToGame()
    {
        escUi.SetActive(false);
        PlayerState.Instance.isUION = false;
        Time.timeScale = 1;
        isEscOn = false;
        cursurManager.SetActive(true);
    }

    //옵션창
    public void OptionUIOn()
    {
        optionUi.SetActive(true);
        bgmSlider.value = UpgradeScript.Instance.bgmValue;
        soundSlider.value = UpgradeScript.Instance.soundValue;
        rotateSlider.value = UpgradeScript.Instance.rotateValue;
    }

    public void OptionUIOff()
    {
        UpgradeScript.Instance.bgmValue = bgmSlider.value;
        UpgradeScript.Instance.soundValue = soundSlider.value;
        UpgradeScript.Instance.rotateValue = rotateSlider.value;

        optionUi.SetActive(false);
    }

    //메인으로
    public void MainUION()
    {
        toMainUi.SetActive(true);
    }

    public void MainUIOff()
    {
        toMainUi.SetActive(false);
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    //게임종료
    public void ExitUION()
    {
        toExitUi.SetActive(true);
    }

    public void ExitUIOff()
    {
        toExitUi.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
