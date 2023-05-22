using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackberry : Item
{
    private string path = "Longvinter_Icons/Plant/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "blackberry";
        data.itemType = (InvenItemType)2;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconBlackberry");
    }
}
