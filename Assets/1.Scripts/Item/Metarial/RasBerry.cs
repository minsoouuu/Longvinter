using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasBerry : Item
{
    public ItemName itemName = ItemName.Raspberry;
    public override void Action()
    {
       Debug.Log(itemName);
    }
}
