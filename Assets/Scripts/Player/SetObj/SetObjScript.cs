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
    private GameObject explosiveObj;
    [SerializeField]
    private Transform objPosition;
    private CheckContactScript checkContact;

    private bool uiActive;
    private int objNum;

    private void Start()
    {
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

            objNum = 0;
        }

        if (Input.GetKeyDown(KeyCode.N) && uiActive)
        {
            uiActive = false;
            interactionObjUI.SetActive(false);
            cursorManager.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
                interactionObj.transform.position = new Vector3(objPosition.position.x, 0.5f, objPosition.position.z);
                checkContact = interactionObj.GetComponent<CheckContactScript>();
                
                if (Input.GetMouseButtonDown(0) && checkContact.contact)
                {
                    Debug.Log("충돌!");
                }

                if (Input.GetMouseButtonDown(0) && !checkContact.contact)
                {
                    Instantiate(explosiveObj, interactionObj.transform.position, Quaternion.identity);
                    objNum = 0;
                    PlayerState.Instance.money -= 500;
                }
                break;
        }
    }
}