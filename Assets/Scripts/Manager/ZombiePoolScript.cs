using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ZombiePoolScript : MonoBehaviour
{
    public static ZombiePoolScript Instance;

    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private int dropMoney;

    private Vector3 myposition;

    public int deadNum;

    Queue<GameObject> zombiePoolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private GameObject CreateNewZombieObject()
    {
        var newObj = Instantiate(zombiePrefab, this.gameObject.transform);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public GameObject GetZombieObject()
    {
        dynamic obj = null;

        if (Instance.zombiePoolQueue.Count == 0)
        {
            obj = Instance.CreateNewZombieObject();
            Instance.zombiePoolQueue.Enqueue(obj);
        }

        obj = Instance.zombiePoolQueue.Dequeue();
        obj.transform.position = myposition;
        obj.SetActive(true);
        obj.transform.SetParent(null);    

        return obj;
    }

    public void PutZombieObject(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(Instance.transform);
        Instance.zombiePoolQueue.Enqueue(Obj);
        if(PlayerState.Instance.Hp > 0)
        {
            PlayerState.Instance.money += dropMoney;
            deadNum++;
        }        
    }

    public void setPosition(Vector3 _position)
    {
        myposition = _position;
    }
}
