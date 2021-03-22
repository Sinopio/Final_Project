using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvenScript : MonoBehaviour
{
    public static PlayerInvenScript Instance;

    [SerializeField]
    private float woodNum;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        woodNum = 0;
    }

    private void Update()
    {
        
    }

    public void getWood()
    {
        woodNum++;        
    }
}
