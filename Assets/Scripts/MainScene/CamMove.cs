using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    private Vector3 home;
    private Vector3 weapon;

    private Vector3 home_r;
    private Vector3 weapon_r;

    private bool atHome;

    private void Start()
    {
        atHome = false;
        home = new Vector3(0, 4.5f, -8);
        weapon = new Vector3(5.5f, 2.5f, 0);
        home_r = new Vector3(21, 0, 0);
        weapon_r = new Vector3(0, 90, 0);
    }

    private void Update()
    {
        if (atHome)
        {
            cam.transform.position = Vector3.Slerp(transform.position, home, 0.5f);
            cam.transform.rotation = Quaternion.Euler(home_r);
        }
        if (!atHome)
        {
            //cam.transform.position = Vector3.Slerp(transform.position, weapon, Time.deltaTime*0.1f);
            cam.transform.rotation = Quaternion.Euler(weapon_r);
        }
    }

    public void goHome()
    {
        atHome = true;
        cam.transform.position = Vector3.Lerp(transform.position, home, 0.1f);
        cam.transform.rotation = Quaternion.Euler(home_r);
    }

    public void goWeapon()
    {
        atHome = false;
        cam.transform.position = Vector3.Slerp(transform.position, weapon, Time.deltaTime * 0.1f);
        cam.transform.rotation = Quaternion.Euler(weapon_r);
    }

}
