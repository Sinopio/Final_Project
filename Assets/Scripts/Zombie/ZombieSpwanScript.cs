using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpwanScript : MonoBehaviour
{
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minZ;
    [SerializeField]
    private float maxZ;
    [SerializeField]
    private float time;
    [SerializeField]
    private float delay;
    [SerializeField]
    private float maxZombie;

    public float paletNum;

    [SerializeField]
    private GameObject paletPosition;

    private float randx;
    private float randz;
    private Transform position;

    private void Start()
    {
        paletNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        randx = Random.Range(minX, maxX);
        randz = Random.Range(minZ, maxZ);
        if (checkTime() && paletNum <= maxZombie)
        {
            paletPosition.transform.position = new Vector3(randx, 0.55f, randz);
            //paletPosition.transform.position = new Vector3(Random.Range(minX, maxX), 0.55f, Random.Range(minZ, maxZ));
            ZombiePoolScript.Instance.setPosition(paletPosition.transform.position);
            ZombiePoolScript.Instance.GetZombieObject();
            paletNum++;
        }
    }

    bool checkTime()
    {
        time -= 0.001f;
        if (time <= 0)
        {
            time = delay;
            return true;
        }

        else
            return false;
    }
}
