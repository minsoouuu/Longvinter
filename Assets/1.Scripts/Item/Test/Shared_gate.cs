using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shared_gate : Item
{
    private string path = "Longvinter_Icons/ItemList/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "shared_gate";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconShared_gate");
    }
}
