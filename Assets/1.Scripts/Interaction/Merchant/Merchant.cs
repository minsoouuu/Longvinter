using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    Slot slot = new Slot();
    Sprite sprite;
    Inven inven;
    Item itemdata;
    int money;

    public void OnClickBuy()
    {
        // slot.SetData(this.transform.GetChild(0).GetComponent<Image>().sprite = this.sprite);
        // inven.Money(money, true);
    }

    public void OnClickSell()
    {
        // slot.SetData(this.transform.GetChild(0).GetComponent<Image>().sprite = this.sprite);
        // inven.Money(money, false);
    }

    void SetSprite(Item itemdata)
    {
        this.itemdata = itemdata;
        sprite = this.itemdata.data.itemImage;
    }
    
}
