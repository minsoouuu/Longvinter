using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image image;

    Item iData;

    public void SetData(Item data)
    {
        iData = data;
        SetSprite();
    }

    public void SetSprite()
    {
        this.image.sprite = iData.data.itemImage;
    }
}
