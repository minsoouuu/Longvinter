using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image image;
    public InvenItemType nowType;

    [HideInInspector] public Item iData;

    public void SetData(Item data)
    {
        iData = data;
        SetType();
        SetSprite();
    }

    
    public void SetType()
    {
        this.nowType = iData.data.itemType;
        
    }

    public void SetSprite()
    {
        this.image.sprite = iData.data.itemImage;
    }
}
