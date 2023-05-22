using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackBar : Item
{
    private string path = "Longvinter_Icons/Consumable/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "snackBar";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconSnackBar");
    }
}
