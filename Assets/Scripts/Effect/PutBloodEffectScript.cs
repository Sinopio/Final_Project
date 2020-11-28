using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBloodEffectScript : MonoBehaviour
{
    private float time;
    private void OnEnable()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            BloodEffectPoolScript.Instance.PutEffect(gameObject);
        }
    }

}
