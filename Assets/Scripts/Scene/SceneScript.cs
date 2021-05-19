using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject stageSelet;
    [SerializeField]
    private Toggle playButton;
    [SerializeField]
    private Toggle stage1Toggle;
    [SerializeField]
    private Toggle stage2Toggle;
    [SerializeField]
    private GameObject stage1HardMode;
    [SerializeField]
    private GameObject stage2HardMode;
    [SerializeField]
    private GameObject stage1Nomal;
    [SerializeField]
    private GameObject stage2Nomal;

    private void Start()
    {
        stageSelet.SetActive(false);
    }

    private void Update()
    {
        setUI();
    }

    void setUI()
    {
        if (playButton.isOn)
        {
            stageSelet.SetActive(true);
        }
        else if (!playButton.isOn)
        {
            stageSelet.SetActive(false);
        }

        if (stage1Toggle.isOn)
        {
            stage1Nomal.SetActive(false);
            stage1HardMode.SetActive(true);
        }
        else if (!stage1Toggle.isOn)
        {
            stage1Nomal.SetActive(true);
            stage1HardMode.SetActive(false);
        }

        if (stage2Toggle.isOn)
        {
            stage2Nomal.SetActive(false);
            stage2HardMode.SetActive(true);
        }
        else if (!stage2Toggle.isOn)
        {
            stage2Nomal.SetActive(true);
            stage2HardMode.SetActive(false);
        }
    }


    public void ToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void StartStage1()
    {
        if (stage1Toggle.isOn)
        {
            SceneManager.LoadScene(2);
        }
        else if (!stage1Toggle.isOn)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void StartStage2()
    {
        if (stage1Toggle.isOn)
        {
            SceneManager.LoadScene(4);
        }
        else if (!stage1Toggle.isOn)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(5);
    }
}
