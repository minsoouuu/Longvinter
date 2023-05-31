using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public int price;
    public int serial;
    public int count;
    public string type;
    public Sprite image;
    public ItemName itemName;
    public InvenItemType itemType;
}

public abstract class Item : MonoBehaviour
{
    public ItemData data = new ItemData();

    private int count = 1;
    
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    public abstract void Use();
}
