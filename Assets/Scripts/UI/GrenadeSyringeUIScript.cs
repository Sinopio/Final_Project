using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSyringeUIScript : MonoBehaviour
{
    [SerializeField]
    private Text grenadeText;
    [SerializeField]
    private Text SyringeText;

    private void Update()
    {
        setText();
    }

    void setText()
    {
        grenadeText.text = "" + PlayerState.Instance.grenadeNum;

        SyringeText.text = "" + PlayerState.Instance.medikitNum;
    }
}
