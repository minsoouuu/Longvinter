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
    [HideInInspector] public MerchantController mc;

    private void Start()
    {
        
    }
   
    public void OnClickBuy()
    {
        Gamemanager.instance.inventory.ADItem(itemdata, true);
        //inven. -= itemdata.data.price;
        mc.CreateMerchant_s_ItemList(mc.num);
    }

    public void OnClickSell()
    {
        Gamemanager.instance.inventory.ADItem(itemdata, false);
        //inven.Money += itemdata.data.price;
        if(itemdata.Count <= 0)
        {
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
        }
    }

    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.image;
        mk.text = itemdata.data.price.ToString();
    }
    
    
}
