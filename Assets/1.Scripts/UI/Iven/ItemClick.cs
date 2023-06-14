using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    private InvenItemClick popup;


    public void ItemChuck()
    {
        //inventory.DeleteItem(slot.item);
        popup.HideTool();
    }

    public void ItemUse()
    {
        //item.Use();
        Debug.Log("아이템을 사용했습니다.");
        popup.HideTool();
    }
}
