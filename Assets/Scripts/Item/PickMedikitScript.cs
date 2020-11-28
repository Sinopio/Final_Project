using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMedikitScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gripIcon;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PlayerState.Instance.medikitNum++;
                gripIcon.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
