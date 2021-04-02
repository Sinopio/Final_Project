using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletPoolScript : MonoBehaviour
{
    public static PaletPoolScript Instance;

    [SerializeField]
    private GameObject palet;
    private Vector3 position;
    Queue<GameObject> paletPoolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private GameObject CreateNewPaletObject()
    {
        var newObj = Instantiate(palet, this.gameObject.transform);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public GameObject GetPaletObject()
    {
        dynamic obj = null;

        if (Instance.paletPoolQueue.Count == 0)
        {
            obj = Instance.CreateNewPaletObject();
            Instance.paletPoolQueue.Enqueue(obj);
        }

        obj = Instance.paletPoolQueue.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        obj.transform.position = position;

        return obj;
    }

    public void PutPaletObject(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.paletPoolQueue.Enqueue(Obj);
    }

    public void setPosition(Vector3 _position)
    {
        position = _position;
    }
}
