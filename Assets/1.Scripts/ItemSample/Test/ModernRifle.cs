using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernRifle : Item
{
    private string path = "Longvinter_Icons/Weapon/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "modernRifle";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconModernRifle");
    }
}