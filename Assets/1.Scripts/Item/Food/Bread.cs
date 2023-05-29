using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Item
{
    public ItemName itemName = ItemName.Bread;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
