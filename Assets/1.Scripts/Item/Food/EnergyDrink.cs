using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : Item
{
    public ItemName itemName = ItemName.EnergyDrink;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
