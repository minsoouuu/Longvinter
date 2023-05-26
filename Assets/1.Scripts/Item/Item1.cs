using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public string name;
    public string image;
    public string type;
    public int price;
    public int serial;
}

public abstract class Item1 : MonoBehaviour
{
    [HideInInspector] public Sprite Icon;

    public ItemName itemType = new ItemName();
    public ItemData data = new ItemData();

    //private InvenItemType invenItem = InvenItemType.data.type;
    private int count = 0;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    private void Start()
    {

    }
    public abstract void Action();
}
