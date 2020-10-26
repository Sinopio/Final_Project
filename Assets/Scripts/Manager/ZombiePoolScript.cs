using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ZombiePoolScript : MonoBehaviour
{
    public static ZombiePoolScript Instance;

    [SerializeField]
    private GameObject zombiePrefab;

    Queue<GameObject> zombiePoolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        Initalize(10);
    }

    private void Initalize(int initcount)
    {
        for(int i = 0; i < initcount; i++)
        {
            zombiePoolQueue.Enqueue(CreateNewZombieObject());
        }
    }

    private GameObject CreateNewZombieObject()
    {
        var newObj = Instantiate(zombiePrefab, this.gameObject.transform);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static GameObject GetZombieObject()
    {
        if(Instance.zombiePoolQueue.Count >0)
        {
            var obj = Instance.zombiePoolQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewZombieObject();
            newObj.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnzombieObject(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.zombiePoolQueue.Enqueue(Obj);
    }
}
