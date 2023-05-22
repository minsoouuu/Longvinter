using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSeeds : Item
{
    private string path = "Longvinter_Icons/Plant/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "wheatSeeds";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconWheatSeeds");
    }
}