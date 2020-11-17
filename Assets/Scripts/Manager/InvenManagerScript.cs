using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunInven;
    [SerializeField]
    private GameObject grenadeInven;
    [SerializeField]
    private GameObject firstAidKit;

    private void Update()
    {
        setInven();
    }

    void setInven()
    { 
        switch(PlayerState.Instance.invenNum)
        {
            case 0:
                gunInven.SetActive(false);
                grenadeInven.SetActive(false);
                firstAidKit.SetActive(false);
                break;
            case 1:
                gunInven.SetActive(true);
                grenadeInven.SetActive(false);
                firstAidKit.SetActive(false);
                break;
            case 2:
                gunInven.SetActive(false);
                grenadeInven.SetActive(false);
                firstAidKit.SetActive(false);
                break;
            case 3:
                gunInven.SetActive(false);
                grenadeInven.SetActive(true);
                firstAidKit.SetActive(false);
                break;
            case 4:
                gunInven.SetActive(false);
                grenadeInven.SetActive(false);
                firstAidKit.SetActive(true);
                break;
        }
    }
}
