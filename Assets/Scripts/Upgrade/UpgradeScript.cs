using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public static UpgradeScript Instance;
    public int money;
    public List<UpgradeInfo> deck = new List<UpgradeInfo>();
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
