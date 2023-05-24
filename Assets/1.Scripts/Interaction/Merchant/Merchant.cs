using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Merchant : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text mk;
    [HideInInspector] public Item itemdata;
    Inventory inven = new Inventory();
    private void Start()
    {
        inven = Gamemanager.instance.inventory;
    }
   
    public void OnClickBuy()
    {
        itemdata.Init();
        inven.AddItem(itemdata);
        inven.Money -= itemdata.data.mk;
    }

    public void OnClickSell()
    {
        inven.DeleteItem(itemdata);
        inven.Money += itemdata.data.mk;
    }

    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.itemImage;
        mk.text = itemdata.data.mk.ToString();
    }
    
}
