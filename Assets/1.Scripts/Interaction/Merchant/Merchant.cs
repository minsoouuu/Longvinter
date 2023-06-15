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
   
    // ���� ��� ��ư �̺�Ʈ
    public void OnClickBuy()
    {
        mc.CreateMerchant_s_ItemList(Gamemanager.instance.player.im.curToggle);
        Gamemanager.instance.inventory.ADItem(itemdata, true);
        //inven. -= itemdata.data.price;
    }


    // �Ǹ� ��� ��ư �̺�Ʈ
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

    // ������ ����
    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.image;
        mk.text = itemdata.data.price.ToString();
    }
    
    
}
