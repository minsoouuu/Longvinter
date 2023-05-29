using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : Item
{
    public ItemName itemName = ItemName.Croissant;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
