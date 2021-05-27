using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public static UpgradeScript Instance;
    public int money;
    public float bgmValue;
    public float soundValue;
    public float rotateValue;

    public bool endTuto;
    public bool endSt1;
    public bool endSt2;
    public bool endSt3;
    public bool endSt4;
    public List<UpgradeInfo> deck = new List<UpgradeInfo>();
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
}
