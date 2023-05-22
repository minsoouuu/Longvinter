using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Item
{
    private string path = "Longvinter_Icons/Equipment/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "hat";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconHat");
    }
}
