using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Transform objPosition;
    [SerializeField]
    private GameObject mouseUi;

    private CheckContactScript checkContact;

    private PlayerMove playerMove;
    private bool uiActive;
    private int objNum;

    private void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        objNum = 0;
        interactionObjUI.SetActive(false);
        uiActive = false;
    }

    private void Update()
    {
        setBuildUI();
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
        }

        if (Input.GetKeyDown(KeyCode.N) && uiActive)
        {
            uiActive = false;
            interactionObjUI.SetActive(false);
            cursorManager.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerMove.enabled = true;
        }
    }

    //메뉴에서 버튼을 눌렀을때
    public void selectExplosive()
    {
        //explosiveObj.SetActive(true);
        uiActive = false;
        interactionObjUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("set Explosive Obj");
        objNum = 1;
        playerMove.enabled = true;
        mouseUi.SetActive(true);
    }

    void setObj()
    {
        switch(objNum)
        {
            case 0:
                interactionObj = null;
                break;
            case 1:
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
                    Instantiate(explosiveObj, interactionObj.transform.position, Quaternion.identity);
                    objNum = 0;
                    mouseUi.SetActive(false);
                    PlayerState.Instance.money -= 500;
                }

                if(Input.GetMouseButtonDown(1))
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
        }
    }
}