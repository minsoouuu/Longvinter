using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingcupSeeds : Item
{
    private string path = "Longvinter_Icons/Plant/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "kingcupSeeds";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconKingcupSeeds");
    }
}
