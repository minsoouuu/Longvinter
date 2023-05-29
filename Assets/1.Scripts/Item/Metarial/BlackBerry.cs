using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBerry : Item
{
    public ItemName itemName = ItemName.Blackberry;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
