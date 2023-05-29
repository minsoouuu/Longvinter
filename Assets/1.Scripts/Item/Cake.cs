using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : Item1
{
    public ItemName itemName = ItemName.Cake;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
