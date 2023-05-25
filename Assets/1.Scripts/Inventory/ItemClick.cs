using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{
    private Inventory inventory;
    private Item item;
    [SerializeField] private GameObject buttons;


    
    public void ItemChuck()
    {
        inventory.DeleteItem(item);
        Destroy(buttons);
    }

    public void ItemUse()
    {
        item.Action();
        Debug.Log("�������� ����߽��ϴ�.");
        Destroy(buttons);
    }
  
}
