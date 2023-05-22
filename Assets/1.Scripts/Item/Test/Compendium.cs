using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compendium : Item
{
    private string path = "Longvinter_Icons/ItemList/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "compendium";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconCompendium");
    }
}