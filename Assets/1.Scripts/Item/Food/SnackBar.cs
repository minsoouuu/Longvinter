using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackBar : Item
{
    public ItemName itemName = ItemName.SnackBar;
    public override void Action()
    {
        Debug.Log(itemName);
    }
}
