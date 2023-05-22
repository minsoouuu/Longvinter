using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Item
{
    private string path = "Longvinter_Icons/Outdoors/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "generator";
        data.itemType = (InvenItemType)1;
        data.itemImage = Resources.Load<Sprite>(path + "T_Generator");
    }
}
