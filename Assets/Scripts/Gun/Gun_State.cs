using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_State : MonoBehaviour
{
    public GameObject Gun_Manager;
    public int Gun_Number;
    private Gun_Manager_Script manager;

    public float Gun_State_Dmg;
    public float Gun_State_Ammo;
    public float Gun_State_Full_Ammo;

    private void Start()
    {
        manager = Gun_Manager.GetComponent<Gun_Manager_Script>();
        Gun_State_Dmg = manager.deck[Gun_Number].Gun_Dmg;
        Gun_State_Ammo = manager.deck[Gun_Number].Gun_Ammo;
        Gun_State_Full_Ammo = manager.deck[Gun_Number].Gun_Full_Ammo;
    }
}
