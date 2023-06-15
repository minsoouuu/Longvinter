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
   
    // 구매 목록 버튼 이벤트
    public void OnClickBuy()
    {
        mc.CreateMerchant_s_ItemList(Gamemanager.instance.player.im.curToggle);
        Gamemanager.instance.inventory.ADItem(itemdata, true);
        //inven. -= itemdata.data.price;
    }


    // 판매 목록 버튼 이벤트
    public void OnClickSell()
    {
        Gamemanager.instance.inventory.ADItem(itemdata, false);
        //inven.Money += itemdata.data.price;
        if(itemdata.data.count <= 0)
        {
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
            mc.merchant_slist.Remove(this.itemdata);
            mc.slot_list.Remove(this);
            this.itemdata.data.count = 1;
        }
        
    }

    // 데이터 세팅
    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.image;
        mk.text = itemdata.data.price.ToString();
    }
    
    
}
