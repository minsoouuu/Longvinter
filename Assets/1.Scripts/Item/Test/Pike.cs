using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : Item
{
    private string path = "Longvinter_Icons/Fish/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "pike";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconPike");
    }
}
