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
    private Slot slot;
    [SerializeField] private GameObject buttons;



    public void OnClickItem(Slot slot)
    {
        GameObject showButtons = Instantiate(buttons, this.transform.position, Quaternion.identity);
        showButtons.transform.SetParent(this.transform);
        popup.SetRectPosition(slot.rt);
        // Why null.....
        //slot -> prefab -> Button

        //???? ???? ?????? ?????? ???? ?? destroy ???? ????
    }

    
    public void ItemChuck()
    {
        inventory.DeleteItem(item);
        Destroy(buttons);
    }

    public void ItemUse()
    {
        item.Action();
        Debug.Log("???????? ????????????.");
        Destroy(buttons);
    }
  
}
