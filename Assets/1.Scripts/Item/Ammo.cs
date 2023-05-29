using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Item1
{
    private string path = "Longvinter_Icons/Weapon/";

    public ItemName itemName = ItemName.Ammo;

    public override void Action()
    {
        Debug.Log(itemName);
    }
}
