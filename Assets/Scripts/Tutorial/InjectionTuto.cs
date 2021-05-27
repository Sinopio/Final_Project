using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InjectionTuto : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private float skipDelay;

    public int cnt;

    [SerializeField]
    private string[] tutoText;
    [SerializeField]
    private int dialogNum;
    [SerializeField]
    private string currentText;

    private PlayerMove playerMove;
    [SerializeField]
    private GameObject player;
    private TutorialText tutorialText;

    private bool textExit;
    private bool textFull;
    private bool textCut;

    private bool dmg;

    private void OnEnable()
    {
        textExit = false;
        textFull = false;
        textCut = false;
        GetText(dialogNum, tutoText);
    }

    private void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        tutorialText = player.GetComponent<TutorialText>();
    }

    void Update()
    {
        if (textExit == true)
        {
            gameObject.SetActive(false);
        }
        setMove();
    }

    void setMove()
    {
        if (cnt < 2)
        {
            PlayerState.Instance.invenNum = 3;
            playerMove.rotateSpeed = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            PlayerState.Instance.isUION = true;
        }
        if (cnt == 3)
        {
            if (!dmg)
            {
                PlayerState.Instance.Hp -= 20;
                dmg = true;
            }
            
            
        }
        if(cnt >=4)
        {
            PlayerState.Instance.isUION = false;
            playerMove.rotateSpeed = 10;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void EndTyping()
    {
        //다음 텍스트 호출
        if (textFull == true)
        {
            cnt++;
            textExit = false;
            textFull = false;
            textCut = false;
            StartCoroutine(ShowText(tutoText));
        }
        //텍스트 타이핑 생략
        else
        {
            textCut = true;
        }
    }

    void GetText(int _dialogNum, string[] _tutoText)
    {
        textExit = false;
        textFull = false;
        textCut = false;
        cnt = 0;

        dialogNum = _dialogNum;
        tutoText = new string[dialogNum];
        tutoText = _tutoText;

        StartCoroutine(ShowText(tutoText));
    }


    IEnumerator ShowText(string[] _tutoText)
    {
        //모든텍스트 종료
        if (cnt >= dialogNum)
        {
            textExit = true;
            StopCoroutine("showText");
        }
        else
        {
            //기존문구clear
            currentText = "";
            //타이핑 시작
            for (int i = 0; i < _tutoText[cnt].Length; i++)
            {
                //타이핑중도탈출
                if (textCut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _tutoText[cnt].Substring(0, i + 1);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            this.GetComponent<Text>().text = _tutoText[cnt];
            yield return new WaitForSeconds(skipDelay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            textFull = true;

        }
    }
}
