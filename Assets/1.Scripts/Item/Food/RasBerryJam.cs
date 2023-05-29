using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasBerryJam : Item
{
    public ItemName itemName = ItemName.RasberryJam;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
