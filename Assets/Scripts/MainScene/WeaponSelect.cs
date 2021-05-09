using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public int objNum = 0;

    //UI
    [SerializeField]
    private GameObject upgradeUI;
    [SerializeField]
    private Camera mainCam;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickObj();
            setObjNim();
            Debug.Log(target);
        }

        if (Input.GetMouseButtonDown(1))
        {
            objNum = 0;
        }

        setUI();
    }

    private GameObject GetClickObj()
    {
        RaycastHit hit;
        Ray ray;
        GameObject _target = null;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(target);
            if (hit.collider.gameObject != null)
            {
                _target = hit.collider.gameObject;
            }
        }

        return _target;
    }

    void setUI()
    {
        if(objNum == 0)
        {
            upgradeUI.SetActive(false);
            mainCam.depth = 1;
        }

        else
        {
            upgradeUI.SetActive(true);
            mainCam.depth = -1;
        }
    }

    void setObjNim()
    {
        if(target.name == "RifleCube")
        {
            objNum = 1;
        }
        else if (target.name == "PistolCube")
        {
            objNum = 2;
        }
        else if (target.name == "KnifeCube")
        {
            objNum = 3;
        }
        else if (target.name == "GrenadeCube")
        {
            objNum = 4;
        }
        else if (target.name == "InjectionCube")
        {
            objNum = 5;
        }
        else if (target.name == "MoveSpeedCube")
        {
            objNum = 6;
        }
    }

    void setUpgradeUI()
    {

    }
}
