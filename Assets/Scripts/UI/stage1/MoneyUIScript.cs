using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIScript : MonoBehaviour
{
    [SerializeField]
    private Text playerHpText;

    // Update is called once per frame
    void Update()
    {
        setPlayerMoneyText();
    }

    void setPlayerMoneyText()
    {
        playerHpText.text = PlayerState.Instance.money.ToString();
    }
}
