using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamiina : Item
{
    private string path = "Longvinter_Icons/Healing&Cooking/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "kamiina";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconKamiina");
    }
}
