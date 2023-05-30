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
    [HideInInspector] public MerchantController mc;

    private void Start()
    {
        inven = Gamemanager.instance.inventory;
    }
   
    public void OnClickBuy()
    {
        inven.Money -= itemdata.data.price;
        List<Item> temp = new List<Item>();
        inven.AddItem(itemdata);
        temp = inven.equipments.ToList();
        for (int i = 0; i < inven.equipments.Count; i++)
        {   
            
            if(mc.s_parent.childCount < inven.equipments.Count)
            {
                for (int j = 0; j < inven.equipments.Count - mc.s_parent.childCount; j++)
                {
                    mc.CreateMerchant_s_ItemList(0);
                }
            }
            mc.s_parent.transform.GetChild(i).gameObject.SetActive(true);
            mc.s_parent.transform.GetChild(i).GetComponent<Merchant>().Setdata(inven.equipments[i]);
        }
        for (int j = mc.s_parent.childCount - 1; j > inven.equipments.Count - 1; j--)
        {
            mc.CreateMerchant_s_ItemList(0);
        }
    }

    public void OnClickSell()
    {
        int count = 0;
        List<Item> temp = new List<Item>();
        temp = inven.equipments.ToList();
        count = temp.Count;
        inven.DeleteItem(itemdata);
        inven.Money += itemdata.data.price;
        if(count != inven.equipments.Count)
        {
            for(int i = 0; i < inven.equipments.Count; i++)
            {
                mc.s_parent.transform.GetChild(i).GetComponent<Merchant>().Setdata(inven.equipments[i]);
            }
            for(int j = mc.s_parent.childCount - 1; j > inven.equipments.Count - 1; j--)
            {
                mc.HideSlot(this);
                mc.s_parent.transform.GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.image;
        mk.text = itemdata.data.price.ToString();
    }
    
    
}
