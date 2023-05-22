using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Item
{
    private string path = "Longvinter_Icons/Weapon/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "ammo";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconAmmo");
        data.mk = 10;
    }
}
