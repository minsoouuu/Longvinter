using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Item
{
    private string path = "Longvinter_Icons/ItemList/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "turret";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconTurret");
        data.mk = 25;
    }
}
