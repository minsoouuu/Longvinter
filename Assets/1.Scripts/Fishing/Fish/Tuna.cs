using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : Fish
{
    public override void Initillize()
    {
        fishData.items = new List<Item>();
        fishData.items.Add(Gamemanager.instance.itemController.GetItem(ItemName.Tuna));
        fishData.speed = 1f;

        fishName = FishName.Tuna;
    }
}
