using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : Item
{
    private string path = "Longvinter_Icons/Consumable/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "croissant";
        data.itemType = 0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconCroissant");
    }
}
