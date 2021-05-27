using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    //메인씬 메인 UI
    [SerializeField]
    private GameObject mainUi;
    //뒤로가기 버튼
    [SerializeField]
    private GameObject backMenu;
    //스테이지 버튼
    [SerializeField]
    private GameObject stageMenu;

    //업그레이드 이미지?
    [SerializeField]
    private GameObject upgradeObj;
    [SerializeField]
    private GameObject upgradeUI;

    //UI에 마우스올렸을때
    [SerializeField]
    private Sprite onImage;
    //UI에 마우스내렸을때
    [SerializeField]
    private Sprite offImage;
    //UI에 마우스올렸을때
    [SerializeField]
    private Sprite onbackImage;
    //UI에 마우스내렸을때
    [SerializeField]
    private Sprite offbackImage;

    [SerializeField]
    private Image stageImage;
    [SerializeField]
    private Image upgradeImage;
    [SerializeField]
    private Image exitImage;
    [SerializeField]
    private Image backImage;

    private void Start()
    {
        mainUi.SetActive(true);
        backMenu.SetActive(false);
        upgradeObj.SetActive(false);
        upgradeUI.SetActive(false);
        stageMenu.SetActive(false);
    }

    //스테이지 선택 쿼드 이미지를 켜고
    //UI로 스테이지 선택이 가능하게 하고
    public void ToStage()
    {
        mainUi.SetActive(false);
        backMenu.SetActive(true);
        upgradeObj.SetActive(false);
        upgradeUI.SetActive(false);
        stageMenu.SetActive(true);
    }

    //업그레이드 UI 좌 우로 나눠서 돌아가면서 총기 보여주기
    //나머지는 UI로 보여주기
    public void ToUpgrade()
    {
        mainUi.SetActive(false);
        backMenu.SetActive(true);
        upgradeObj.SetActive(true);
        upgradeUI.SetActive(true);
        stageMenu.SetActive(false);
    }

    public void ToMain()
    {
        mainUi.SetActive(true);
        backMenu.SetActive(false);
        upgradeObj.SetActive(false);
        upgradeUI.SetActive(false);
        stageMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
    }

    public void MouseOnStage()
    {
        stageImage.sprite = offImage;
    }

    public void MouseOffStage()
    {
        stageImage.sprite = onImage;
    }

    public void MouseOnUpgrade()
    {
        upgradeImage.sprite = offImage;
    }

    public void MouseOffUpgrade()
    {
        upgradeImage.sprite = onImage;
    }

    public void MouseOnExit()
    {
        exitImage.sprite = offImage;
    }

    public void MouseOffExit()
    {
        exitImage.sprite = onImage;
    }

    public void MouseOnBack()
    {
        backImage.sprite = offbackImage;
    }

    public void MouseOffBack()
    {
        backImage.sprite = onbackImage;
    }
}
