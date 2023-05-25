using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{
    private Inventory inventory;
    private ItemPopUp popup;
    private Slot slot;
    private Item1 item;
    [SerializeField] private GameObject buttons;


    
    public void ItemChuck()
    {
        inventory.DeleteItem(slot.item);
        popup.HideTool();
    }

    public void ItemUse()
    {
        item.Action();
        Debug.Log("아이템을 사용했습니다.");
        popup.HideTool();
    }
  
}
