using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image image;

    ItemData iData;

    public void SetData(ItemData data)
    {
        iData = data;
        SetSprite();
    }

    public void SetSprite()
    {
        image.enabled = true;
        this.image.sprite = iData.itemImage;
    }
}
