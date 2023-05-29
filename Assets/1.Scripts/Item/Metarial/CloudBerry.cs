using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBerry : Item
{
    public ItemName itemName = ItemName.Cloudberry;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
