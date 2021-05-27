using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelUpgrade : MonoBehaviour
{
    public int objNum = 1;

    [SerializeField]
    private Sprite onImage;
    [SerializeField]
    private Sprite offImage;

    [SerializeField]
    private Image leftImage;
    [SerializeField]
    private Image rightImage;

    public void leftWeapon()
    {
        if (objNum >= 2)
        {
            objNum--;
        }
    }

    public void rightWeapon()
    {
        if (objNum <= 5)
        {
            objNum++;
        }
    }

    public void OnLeftMouse()
    {
        leftImage.sprite = onImage;
    }

    public void OffLeftMouse()
    {
        leftImage.sprite = offImage;
    }

    public void OnRightMouse()
    {
        rightImage.sprite = onImage;
    }

    public void OffRightMouse()
    {
        rightImage.sprite = offImage;
    }
}
