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
        if (Instance.paletPoolQueue.Count > 0)
        {
            var obj = Instance.paletPoolQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            obj.transform.position = position;
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewPaletObject();
            newObj.SetActive(true);
            newObj.transform.SetParent(null);
            newObj.transform.position = position;
            return newObj;
        }
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
