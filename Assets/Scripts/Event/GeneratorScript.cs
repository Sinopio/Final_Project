using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorScript : MonoBehaviour
{
    public static GeneratorScript Instance;
    public bool alert;
    private bool inGeneratorArea;
    private float generatorRunTime;
    private double generatorFixTime;

    public Transform objTrasnform;
    [SerializeField]
    private GameObject eventGoalUI;
    [SerializeField]
    private GameObject gameGoalUI;
    [SerializeField]
    private GameObject fixGeneratorUI;
    [SerializeField]
    private Text lastTimeUI;
    [SerializeField]
    private GameObject itemBarUi;
    [SerializeField]
    private Image generatorBar;
    [SerializeField]
    private GameObject fixIcon;
    [SerializeField]
    private GameObject crosshair;

    private void Awake()
    {
        Instance = this;
        objTrasnform = gameObject.transform;
    }

    private void Update()
    {
        triggerGenerator();
        defenceTime();
    }

    void triggerGenerator()
    {
        if (inGeneratorArea && Input.GetKey(KeyCode.E) && !alert)
        {
            itemBarUi.SetActive(true);
            generatorRunTime += Time.deltaTime;
            if (generatorRunTime <= 3)
            {
                generatorBar.fillAmount = generatorRunTime / 3.0f;

            }
            else if (generatorRunTime > 3)
            {
                itemBarUi.SetActive(false);
                alert = true;
                generatorRunTime = 0;
            }
            crosshair.SetActive(false);
            fixIcon.SetActive(true);
        }

        if (!alert && Input.GetKeyUp(KeyCode.E))
        {
            itemBarUi.SetActive(false);
            generatorRunTime = 0;
            crosshair.SetActive(true);
            fixIcon.SetActive(false);
        }

        if(alert)
        {
            crosshair.SetActive(true);
            fixIcon.SetActive(false);
        }
    }

    void defenceTime()
    {
        double lastTime = 60 - (Math.Truncate(generatorFixTime*10) / 10);
        if (alert)
        {
            generatorFixTime += Time.deltaTime;
            gameGoalUI.SetActive(false);
            eventGoalUI.SetActive(true);
            fixGeneratorUI.SetActive(false);
            lastTimeUI.text = lastTime.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inGeneratorArea = true;
            fixGeneratorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inGeneratorArea = false;
            fixGeneratorUI.SetActive(false);
        }
        crosshair.SetActive(true);
        fixIcon.SetActive(false);
    }
}
