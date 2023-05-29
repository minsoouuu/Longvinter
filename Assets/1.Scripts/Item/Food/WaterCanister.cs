using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanister : Item
{
    public ItemName itemName = ItemName.WaterCanister;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
