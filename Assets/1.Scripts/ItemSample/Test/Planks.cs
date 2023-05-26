using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planks : Item
{
    private string path = "Longvinter_Icons/Components/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "planks";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconPlanks");
    }
}