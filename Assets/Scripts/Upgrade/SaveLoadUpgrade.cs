using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUpgrade : MonoBehaviour
{
    [SerializeField]
    private bool initSave;

    private void Start()
    {
        InitUpgrade();
    }

    private void OnApplicationQuit()
    {
        if (initSave)
        {
            InitSave();
        }
        else if(!initSave)
        {
            SaveUpgrade();
        }
    }

    private void Update()
    {
        if(initSave)
        {
            InitSave();
        }       
    }

    void InitUpgrade()
    {
        if(!PlayerPrefs.HasKey("RifleUp1"))
        {
            PlayerPrefs.SetFloat("RifleUp1", 0);
            PlayerPrefs.SetFloat("RifleUp2", 0);
            //피스톨
            PlayerPrefs.SetFloat("PistolUp1", 0);
            PlayerPrefs.SetFloat("PistolUp2", 0);
            //칼
            PlayerPrefs.SetFloat("KnifeUp1", 0);
            //수류탄
            PlayerPrefs.SetFloat("GrenadeUp1", 0);
            //인젝션
            PlayerPrefs.SetFloat("InjectionUp1", 0);
            //플레이어
            PlayerPrefs.SetFloat("PlayerUp1", 0);
            PlayerPrefs.SetFloat("PlayerUp2", 0);
            //돈
            PlayerPrefs.SetInt("Money", 100000);
        }

        else if (PlayerPrefs.HasKey("RifleUp1"))
        {
            LoadUpgrade();
        }
    }

    void SaveUpgrade()
    {
        //라이플
        PlayerPrefs.SetFloat("RifleUp1",UpgradeScript.Instance.deck[0].nowUpgrade1);
        PlayerPrefs.SetFloat("RifleUp2", UpgradeScript.Instance.deck[0].nowUpgrade2);
        //피스톨
        PlayerPrefs.SetFloat("PistolUp1", UpgradeScript.Instance.deck[1].nowUpgrade1);
        PlayerPrefs.SetFloat("PistolUp2", UpgradeScript.Instance.deck[1].nowUpgrade2);
        //칼
        PlayerPrefs.SetFloat("KnifeUp1", UpgradeScript.Instance.deck[2].nowUpgrade1);
        //수류탄
        PlayerPrefs.SetFloat("GrenadeUp1", UpgradeScript.Instance.deck[3].nowUpgrade1);
        //인젝션
        PlayerPrefs.SetFloat("InjectionUp1", UpgradeScript.Instance.deck[4].nowUpgrade1);
        //플레이어
        PlayerPrefs.SetFloat("PlayerUp1", UpgradeScript.Instance.deck[5].nowUpgrade1);
        PlayerPrefs.SetFloat("PlayerUp2", UpgradeScript.Instance.deck[5].nowUpgrade2);
        //돈
        PlayerPrefs.SetInt("Money", UpgradeScript.Instance.money);

        PlayerPrefs.Save();
    }

    void LoadUpgrade()
    {
        UpgradeScript.Instance.deck[0].nowUpgrade1 = PlayerPrefs.GetFloat("RifleUp1");
        UpgradeScript.Instance.deck[0].nowUpgrade2 = PlayerPrefs.GetFloat("RifleUp2");
        //피스톨
        UpgradeScript.Instance.deck[1].nowUpgrade1 = PlayerPrefs.GetFloat("PistolUp1");
        UpgradeScript.Instance.deck[1].nowUpgrade2 = PlayerPrefs.GetFloat("PistolUp2");
        //칼
        UpgradeScript.Instance.deck[2].nowUpgrade1 = PlayerPrefs.GetFloat("KnifeUp1");
        //수류탄
        UpgradeScript.Instance.deck[3].nowUpgrade1 = PlayerPrefs.GetFloat("GrenadeUp1");
        //인젝션
        UpgradeScript.Instance.deck[4].nowUpgrade1 = PlayerPrefs.GetFloat("InjectionUp1");
        //플레이어
        UpgradeScript.Instance.deck[5].nowUpgrade1 = PlayerPrefs.GetFloat("PlayerUp1");
        UpgradeScript.Instance.deck[5].nowUpgrade2 = PlayerPrefs.GetFloat("PlayerUp2");
        //돈
        UpgradeScript.Instance.money = PlayerPrefs.GetInt("Money");
    }

    void InitSave()
    {
        PlayerPrefs.SetFloat("RifleUp1", 0);
        PlayerPrefs.SetFloat("RifleUp2", 0);
        //피스톨
        PlayerPrefs.SetFloat("PistolUp1", 0);
        PlayerPrefs.SetFloat("PistolUp2", 0);
        //칼
        PlayerPrefs.SetFloat("KnifeUp1", 0);
        //수류탄
        PlayerPrefs.SetFloat("GrenadeUp1", 0);
        //인젝션
        PlayerPrefs.SetFloat("InjectionUp1", 0);
        //플레이어
        PlayerPrefs.SetFloat("PlayerUp1", 0);
        PlayerPrefs.SetFloat("PlayerUp2", 0);
        //돈
        PlayerPrefs.SetInt("Money", 100000);

        PlayerPrefs.Save();
    }
}
