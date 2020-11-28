using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffectPoolScript : MonoBehaviour
{
    public static BloodEffectPoolScript Instance;

    [SerializeField]
    private GameObject bloodEffectObj;

    private Vector3 hitPosition;
    Queue<GameObject> effectObjPoolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private GameObject CreateNewEffect()
    {
        var newObj = Instantiate(bloodEffectObj, this.gameObject.transform);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public GameObject GetEffect()
    {
        if (Instance.effectObjPoolQueue.Count > 0)
        {
            var obj = Instance.effectObjPoolQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            obj.transform.position = hitPosition;
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewEffect();
            newObj.SetActive(true);
            newObj.transform.position = hitPosition;
            newObj.transform.SetParent(null);            
            return newObj;
        }
    }

    public void PutEffect(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.effectObjPoolQueue.Enqueue(Obj);
    }

    public void setPosition(Vector3 position)
    {
        hitPosition = position;
    }
}
