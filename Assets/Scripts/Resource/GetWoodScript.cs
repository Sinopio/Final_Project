using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWoodScript : MonoBehaviour
{
    [SerializeField]
    private float Hp;


    private void Update()
    {
        if(Hp <= 0)
        {
            PaletPoolScript.Instance.PutPaletObject(gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KnifeAtk")
        {
            PlayerInvenScript.Instance.getWood();
            Hp--;
        }
    }
}
