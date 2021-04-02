using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{
    public static BulletPoolScript Instance;

    [SerializeField]
    private GameObject bulletObject;

    Queue<GameObject> bulletPoolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private GameObject CreateNewBullet()
    {
        var newObj = Instantiate(bulletObject, this.gameObject.transform);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public GameObject GetBullet()
    {
        dynamic obj = null;

        if (Instance.bulletPoolQueue.Count == 0)
        {
            obj = Instance.CreateNewBullet();
            Instance.bulletPoolQueue.Enqueue(obj);
        }

        obj = Instance.bulletPoolQueue.Dequeue();

        obj.SetActive(true);
        obj.transform.SetParent(null);
        return obj;
    }

    public void PutBullet(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.bulletPoolQueue.Enqueue(Obj);
    }
}
