using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Item
{
    private string path = "Longvinter_Icons/ItemList/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "container";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconContainer");
    }
}
