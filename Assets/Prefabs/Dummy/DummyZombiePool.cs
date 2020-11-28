using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyZombiePool : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    GeneratorScript generatorScript;
    [SerializeField]
    private GameObject generator;

    private bool isAlert;


    private float randX = 0;
    private float randZ = 0;

    private void Start()
    {
        isAlert = false;
        generatorScript = generator.GetComponent<GeneratorScript>();
    }

    private void Update()
    {
        spwanZombie();
        alertSpwanZombie();
    }

    void spwanZombie()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            randX = Random.Range(-5, 5);
            randZ = Random.Range(-5, 5);
            var ZombieObj = ZombiePoolScript.Instance.GetZombieObject();
            ZombieObj.transform.position = new Vector3(player.transform.position.x + randX, player.transform.position.y, player.transform.position.z + randZ);
        }
    }

    void alertSpwanZombie()
    {
        if(generatorScript.alert && !isAlert)
        {
            for(int i = 0; i <= 10; i++)
            {
                randX = Random.Range(-1, 1);
                randZ = Random.Range(-1, 1);

                var ZombieObj = ZombiePoolScript.Instance.GetZombieObject();
                ZombieObj.transform.position = new Vector3(gameObject.transform.position.x + randX, gameObject.transform.position.y, gameObject.transform.position.z + randZ);
            }
            isAlert = true;
        }
    }
}
