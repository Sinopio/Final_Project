using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimerScript : MonoBehaviour
{
    [SerializeField]
    private float timer;
    [SerializeField]
    private float limit;

    private void Update()
    {
        setFalseUI();
    }

    void setFalseUI()
    {
        timer += Time.deltaTime;
        if(timer >= limit)
        {
            gameObject.SetActive(false);
        }
    }
}
