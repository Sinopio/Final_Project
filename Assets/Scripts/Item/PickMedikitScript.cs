using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMedikitScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PlayerState.Instance.medikitNum++;
                gameObject.SetActive(false);
            }
        }
    }
}
