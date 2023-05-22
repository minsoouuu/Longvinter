using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : Item
{
    private string path = "Longvinter_Icons/Plant/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "seeds";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconSeeds");
    }
}
