using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gun_Script : MonoBehaviour
{
    public GameObject gun_Object;
    private Gun_State gun_State;
    public int gun_num;
    public bool can_pickup;
    public bool is_pickup;

    public GameObject gun0;
    public GameObject gun1;

    private void Start()
    {
        can_pickup = false;
        is_pickup = false;
    }

    private void Update()
    {
        PickUp_Gun();
        Get_Gunscript();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Gun")
        {
            can_pickup = true;
            gun_Object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gun")
        {
            can_pickup = false;
            gun_Object = null;
        }
    }

    void PickUp_Gun()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(can_pickup)
            {
               switch (gun_num)
                {
                    case 0:
                        gun0.SetActive(true);
                        gun1.SetActive(false);
                        is_pickup = true;
                        break;
                    case 1:
                        gun0.SetActive(false);
                        gun1.SetActive(true);
                        is_pickup = true;
                        break;
                } 
            }
        }
    }

    void Get_Gunscript()
    {
        if(gun_Object != null)
        {
            gun_State = gun_Object.GetComponent<Gun_State>();
            gun_num = gun_State.Gun_Number;
        }

        else
        {
            gun_num = -1;
        }
    }
}
