using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPack : Item
{
    public ItemName itemName = ItemName.HeatPack;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
