using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : Fish
{
    public override void Initillize()
    {
        dropItem.items = new List<Item>();
        dropItem.items.Add(Gamemanager.instance.itemController.GetItem(ItemName.Tuna));
    }
}
