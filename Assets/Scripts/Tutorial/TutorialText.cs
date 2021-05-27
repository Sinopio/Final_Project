using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tutoTextObj;
    /*
        0 - moveTutoObj
        1 - moveTutoText

        2 - shotTutoObj
        3 - shotTutoText

        4 5 - grenade

        6 7 - injection
    */

    private TutoText tutoText;
    private ShotTuto shotTuto;
    private GrenadeTuto grenadeTuto;
    private InjectionTuto injectionTuto;

    public int tutoState;

    private void Start()
    {
        tutoText = tutoTextObj[1].GetComponent<TutoText>();
        shotTuto = tutoTextObj[3].GetComponent<ShotTuto>();
        grenadeTuto = tutoTextObj[5].GetComponent<GrenadeTuto>();
        injectionTuto = tutoTextObj[7].GetComponent<InjectionTuto>();
        PlayerState.Instance.invenNum = 50;
    }

    private void Update()
    {
        setText();
    }

    void setText()
    {
        if(ZombiePoolScript.Instance.deadNum == 1)
        {
            tutoState = 2;
        }
        if (ZombiePoolScript.Instance.deadNum == 2)
        {
            tutoState = 3;
        }
        if(PlayerState.Instance.Hp == PlayerState.Instance.MaxHp && injectionTuto.cnt >=4)
        {
            tutoState = 4;
        }

        switch(tutoState)
        {
            //move
            case 0:
                tutoTextObj[0].SetActive(true);
                tutoTextObj[2].SetActive(false);
                tutoTextObj[4].SetActive(false);
                tutoTextObj[6].SetActive(false);
                tutoTextObj[8].SetActive(false);
                break;
                //shot
            case 1:
                tutoTextObj[0].SetActive(false);
                tutoTextObj[2].SetActive(true);
                tutoTextObj[4].SetActive(false);
                tutoTextObj[6].SetActive(false);
                tutoTextObj[8].SetActive(false);
                break;
                //grenade
            case 2:
                tutoTextObj[0].SetActive(false);
                tutoTextObj[2].SetActive(false);
                tutoTextObj[4].SetActive(true);
                tutoTextObj[6].SetActive(false);
                tutoTextObj[8].SetActive(false);
                break;
                //injection
            case 3:
                tutoTextObj[0].SetActive(false);
                tutoTextObj[2].SetActive(false);
                tutoTextObj[4].SetActive(false);
                tutoTextObj[6].SetActive(true);
                tutoTextObj[8].SetActive(false);
                break;
                //shop
            case 4:
                tutoTextObj[0].SetActive(false);
                tutoTextObj[2].SetActive(false);
                tutoTextObj[4].SetActive(false);
                tutoTextObj[6].SetActive(false);
                tutoTextObj[8].SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tutorial" && tutoState == 0)
        {
            tutoState++;
        }
    }
}
