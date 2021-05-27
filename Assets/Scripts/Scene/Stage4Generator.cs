using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Generator : MonoBehaviour
{
    public float generatorHp;
    public float generatorFullHp;

    // Start is called before the first frame update
    void Start()
    {
        generatorHp = generatorFullHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZombieAtk")
        {
            generatorHp -= 1;
        }
    }
}
