using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyZombiePool : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private float randX = 0;
    private float randZ = 0;

    private void Update()
    {
        spwanZombie();
    }

    void spwanZombie()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            randX = Random.Range(-5, 5);
            randZ = Random.Range(-5, 5);
            var ZombieObj = ZombiePoolScript.GetZombieObject();
            ZombieObj.transform.position = new Vector3(player.transform.position.x + randX, player.transform.position.y, player.transform.position.z + randZ);
        }
    }
}
