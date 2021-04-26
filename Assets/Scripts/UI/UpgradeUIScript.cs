using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIScript : MonoBehaviour
{
    [SerializeField]
    private Text dmgUpText;
    [SerializeField]
    private Text speedUpText;

    private void Update()
    {
        setText();
    }

    void setText()
    {
        dmgUpText.text = "" + PlayerState.Instance.grenadeNum;

        speedUpText.text = "" + PlayerState.Instance.medikitNum;
    }
}
