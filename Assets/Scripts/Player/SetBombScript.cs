using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBombScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private GameObject throwPosition;

    public bool isSet;

    private void Start()
    {
        isSet = false;
    }

    private void Update()
    {
        setBomb();        
    }

    void setBomb()
    {
        if(!isSet)
        {
            bomb.transform.position = throwPosition.transform.position;
        }        

        if (PlayerState.Instance.invenNum == 10 && Input.GetMouseButtonDown(0))
        {
            isSet = true;
            bomb.SetActive(true);
        }
    }
}
