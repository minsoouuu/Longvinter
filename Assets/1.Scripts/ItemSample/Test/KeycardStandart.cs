using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardStandart : Item
{
    private string path = "Longvinter_Icons/Equipment/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "keycardStandart";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconKeycardStandart");
    }
}