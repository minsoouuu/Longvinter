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
        //slot�� ���������� ����� �Ƿ���..

        //�ٸ� ��ư ������ ������ ���� �� destroy ���� �ʿ�
    }

    
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
