using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcticChar : Item
{
    private string path = "Longvinter_Icons/Fish/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "arcticChar";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconArcticChar");
        data.mk = 5;
    }
}
