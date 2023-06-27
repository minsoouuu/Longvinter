using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public int price;
    public int serial;
    public int stats;
    public Sprite image;
    public ItemName itemName;
    public InvenItemType itemType;
}

public abstract class Item : MonoBehaviour
{
    public ItemData data = new ItemData();

    public virtual void Use()
    {
        Gamemanager.instance.player.im.ADItem(this, false);
    }
}
