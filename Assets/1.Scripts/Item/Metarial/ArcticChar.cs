using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcticChar : Item
{
   public ItemName itemName = ItemName.ArcticChar;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
