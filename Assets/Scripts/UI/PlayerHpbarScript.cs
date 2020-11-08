using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpbarScript : MonoBehaviour
{
    [SerializeField]
    private Image playerHpBar;
    [SerializeField]
    private Text playerHpText;
    private void Update()
    {
        setPlayerHpBar();
        setPlayerHpText();
    }

    void setPlayerHpBar()
    {
        float HP = PlayerState.Instance.Hp / PlayerState.Instance.MaxHp;
        playerHpBar.fillAmount = HP;
    }

    void setPlayerHpText()
    {
        playerHpText.text = PlayerState.Instance.Hp.ToString();
    }
}
