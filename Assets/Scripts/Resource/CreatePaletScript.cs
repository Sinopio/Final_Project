using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePaletScript : MonoBehaviour
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
    private float maxPalet;

    public float paletNum;

    [SerializeField]
    private GameObject paletPosition;

    private void Start()
    {
        paletNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkTime() && paletNum <= maxPalet)
        {
            paletPosition.transform.position = new Vector3(Random.Range(minX, maxX), 0.55f, Random.Range(minZ, maxZ));
            PaletPoolScript.Instance.setPosition(paletPosition.transform.position);
            PaletPoolScript.Instance.GetPaletObject();
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
