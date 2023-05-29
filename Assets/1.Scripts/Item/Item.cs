using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct ItemData
{
    public string image;
    public string type;
    public int price;
    public int serial;
    public ItemName itemName;
    public InvenItemType itemType;
}

public abstract class Item : MonoBehaviour
{
    [HideInInspector] public Sprite Icon;
    public ItemData data = new ItemData();


    //private InvenItemType invenItem = InvenItemType.data.type;
    private int count = 0;
    
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    public abstract void Action();
}
