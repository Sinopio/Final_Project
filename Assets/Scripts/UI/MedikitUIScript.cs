using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedikitUIScript : MonoBehaviour
{
    [SerializeField]
    private Text medikitText;

    private void Update()
    {
        setMedikitUI();
    }

    void setMedikitUI()
    {
        medikitText.text = PlayerState.Instance.medikitNum.ToString();
    }
}
