using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    private Inventory inventory;
    private ItemPopUp popup;
    private Slot slot;
    private Item item;


    public void ItemChuck()
    {
        inventory.DeleteItem(slot.item);
        popup.HideTool();
    }

    public void ItemUse()
    {
        item.Action();
        Debug.Log("�������� ����߽��ϴ�.");
        popup.HideTool();
    }
  
}
