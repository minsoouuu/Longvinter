using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : Item
{
    private string path = "Longvinter_Icons/Outdoors/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "tent";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconTent");
        data.mk = 20;
    }
}
