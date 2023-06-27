using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Item
{
    public override void Use()
    {
        base.Use();
        BuildingSystem.b_instance.Create_prefab(data.itemName.ToString());
    }
}
