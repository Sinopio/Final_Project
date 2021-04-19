using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoScirpt : MonoBehaviour
{
    [SerializeField]
    private Text objInfo;

    public void enterExplosive()
    {
        objInfo.text = " 폭발형 함정을 설치합니다. \n\n\n\n\n\n $:500";
    }

    public void exitButtonUi()
    {
        objInfo.text = "";
    }
}
