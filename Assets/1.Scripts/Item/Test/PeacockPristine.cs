using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacockPristine : Item
{
    private string path = "Longvinter_Icons/Feather/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "peacockPristine";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconPeacockPristine");
    }
}
