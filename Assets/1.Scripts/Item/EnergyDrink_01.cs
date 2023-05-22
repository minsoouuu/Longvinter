using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink_01 : Item
{
    private string path = "Longvinter_Icons/Consumable/";

    public override void Action()
    {

    }

    public override void Init()
    {
        data.itemName = "energyDrink_01";
        data.itemType = (InvenItemType)0;
        data.itemImage = Resources.Load<Sprite>(path + "T_IconEnergyDrink_01");
    }
}
