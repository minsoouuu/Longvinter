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
        Debug.Log("�������� ����߽��ϴ�.");
        popup.HideTool();
    }
}
