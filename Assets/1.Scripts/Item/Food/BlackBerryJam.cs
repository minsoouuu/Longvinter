using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBerryJam : Item
{
    public ItemName itemName = ItemName.BlackberryJam;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
