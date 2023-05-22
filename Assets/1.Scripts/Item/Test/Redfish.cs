using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redfish : Item
{
    private string path = "Longvinter_Icons/Fish/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "redfish";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconRedfish");
    }
}