using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedikitUIScript : MonoBehaviour
{
    [SerializeField]
    private Text medikitText;
    private float recoveryTime = 0;
    [SerializeField]
    private GameObject itemBarUi;
    [SerializeField]
    private Image medikitBar;

    private void Update()
    {
        setMedikitUI();
        useMedikitUI();
    }

    void setMedikitUI()
    {
        medikitText.text = PlayerState.Instance.medikitNum.ToString();
    }

    void useMedikitUI()
    {
        if(PlayerState.Instance.Hp < 80 && Input.GetKey(KeyCode.E))
        {
            itemBarUi.SetActive(true);
            recoveryTime += Time.deltaTime;
            if(recoveryTime < 3.0f)
            {
                medikitBar.fillAmount = recoveryTime / 3.0f;
            }
            else if (recoveryTime > 3.0f)
            {
                itemBarUi.SetActive(false);
                recoveryTime = 0.0f;

            }
        }
    }
}
