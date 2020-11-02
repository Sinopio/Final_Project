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
        if (Instance.bulletPoolQueue.Count > 0)
        {
            var obj = Instance.bulletPoolQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewBullet();
            newObj.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public void PutBullet(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.bulletPoolQueue.Enqueue(Obj);
    }
}
