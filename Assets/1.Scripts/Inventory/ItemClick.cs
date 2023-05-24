using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour
{
    private Inventory inventory;
    private Item item;
    private ItemPopUp popup;
    [SerializeField] private GameObject buttons;



    public void OnClickItem(ItemPopUp slot)
    {
        GameObject showButtons = Instantiate(buttons, this.transform.position, Quaternion.identity);
        showButtons.transform.SetParent(this.transform);
        popup.SetRectPosition(slot.SlotRect);
        //slot을 프리팹으로 만들면 되려나..

        //다른 버튼 누르면 직전에 만든 건 destroy 구현 필요
    }

    
    public void ItemChuck()
    {
        inventory.DeleteItem(item);
        Destroy(buttons);
    }

    public void ItemUse()
    {
        item.Action();
        Debug.Log("아이템을 사용했습니다.");
        Destroy(buttons);
    }
  
}
