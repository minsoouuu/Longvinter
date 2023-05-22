using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupChanterelle : Item
{
    private string path = "Longvinter_Icons/Consumable/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "soupChanterelle";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconSoupChanterelle");
    }
}
