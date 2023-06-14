using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    Item item;
    public override void Use()
    {
        item = Gamemanager.instance.itemController.GetItem(ItemName.Bread, InvenItemType.Foods);
    }
}
