using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBerryJam : Item
{
    public ItemName itemName = ItemName.CloudberryJam;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
