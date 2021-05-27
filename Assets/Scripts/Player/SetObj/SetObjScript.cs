using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetObjScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorManager;
    [SerializeField]
    private GameObject interactionObjUI;
    [SerializeField]
    private GameObject interactionObj;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject explosiveObj;
    [SerializeField]
    private GameObject explosiveObjPrefabs;
    [SerializeField]
    private GameObject blockObj;
    [SerializeField]
    private Transform objPosition;
    [SerializeField]
    private GameObject mouseUi;

    private CheckContactScript checkContact;

    private PlayerMove playerMove;
    private bool uiActive;
    private int objNum;

    [SerializeField]
    private Text shopInfo;

    private ShopScript shopScript;
    [SerializeField]
    private GameObject shopManager;

    private void Start()
    {
        mouseUi.SetActive(false);
        shopScript = shopManager.GetComponent<ShopScript>();
        playerMove = player.GetComponent<PlayerMove>();
        objNum = 0;
        interactionObjUI.SetActive(false);
        uiActive = false;
    }

    private void Update()
    {
        //setBuildUI();
        setObj();
    }

    void setBuildUI()
    {
        if (Input.GetKeyDown(KeyCode.B) && !uiActive)
        {
            uiActive = true;
            interactionObjUI.SetActive(true);
            cursorManager.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            playerMove.enabled = false;
            objNum = 0;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.N) && uiActive)
        {
            uiActive = false;
            interactionObjUI.SetActive(false);
            cursorManager.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerMove.enabled = true;
            Time.timeScale = 1;
        }
    }

    //메뉴에서 버튼을 눌렀을때
    public void selectExplosive()
    {
        if (PlayerState.Instance.money >= 300)
        {
            //explosiveObj.SetActive(true);
            shopScript.uiActive = false;
            interactionObjUI.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("set Explosive Obj");

            objNum = 1;
            playerMove.enabled = true;
            mouseUi.SetActive(true);

            PlayerState.Instance.isUION = false;

            Time.timeScale = 1;
        }
        else if (PlayerState.Instance.money < 300)
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    public void selectBlock()
    {
        if (PlayerState.Instance.money >= 500)
        {
            shopScript.uiActive = false;
            interactionObjUI.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("set Block Obj");

            objNum = 2;
            playerMove.enabled = true;
            mouseUi.SetActive(true);

            PlayerState.Instance.isUION = false;

            Time.timeScale = 1;
        }
        else if (PlayerState.Instance.money < 500)
        {
            shopInfo.text = "보유한 돈이 부족합니다.";
        }
    }

    void setObj()
    {
        switch (objNum)
        {
            case 0:
                interactionObj = null;
                break;

            case 1:
                PlayerState.Instance.invenNum = 3;
                interactionObj = explosiveObj;
                interactionObj.SetActive(true);
                interactionObj.transform.position = new Vector3(objPosition.position.x, 0.55f, objPosition.position.z);
                checkContact = interactionObj.GetComponent<CheckContactScript>();

                if (Input.GetMouseButtonDown(0) && checkContact.contact)
                {
                    Debug.Log("충돌!");
                }

                if (Input.GetMouseButtonDown(0) && !checkContact.contact)
                {
                    Instantiate(explosiveObjPrefabs, interactionObj.transform.position, Quaternion.identity);
                    interactionObj.SetActive(false);
                    objNum = 0;
                    mouseUi.SetActive(false);
                    PlayerState.Instance.money -= 500;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    objNum = 0;
                    explosiveObj.SetActive(false);
                    mouseUi.SetActive(false);
                    uiActive = false;
                    interactionObjUI.SetActive(false);
                    cursorManager.SetActive(true);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    playerMove.enabled = true;
                }
                break;

            case 2:
                PlayerState.Instance.invenNum = 3;
                interactionObj = blockObj;
                interactionObj.SetActive(true);
                interactionObj.transform.position = new Vector3(objPosition.position.x, 0.55f, objPosition.position.z);
                checkContact = interactionObj.GetComponent<CheckContactScript>();

                if (Input.GetMouseButtonDown(0) && checkContact.contact)
                {
                    Debug.Log("충돌!");
                }

                if (Input.GetMouseButtonDown(0) && !checkContact.contact)
                {
                    Instantiate(blockObj, interactionObj.transform.position, Quaternion.identity);
                    interactionObj.SetActive(false);
                    objNum = 0;
                    mouseUi.SetActive(false);
                    PlayerState.Instance.money -= 500;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    objNum = 0;
                    blockObj.SetActive(false);
                    mouseUi.SetActive(false);
                    uiActive = false;
                    interactionObjUI.SetActive(false);
                    cursorManager.SetActive(true);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    playerMove.enabled = true;
                }
                break;
        }
    }

    public void GetOut()
    {
        uiActive = false;
        interactionObjUI.SetActive(false);
        cursorManager.SetActive(true);
        playerMove.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}