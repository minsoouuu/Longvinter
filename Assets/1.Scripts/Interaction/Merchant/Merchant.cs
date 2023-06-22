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

        if (Gamemanager.instance.player.im.Money < itemdata.data.price)
        {
            OneButtonPopUpManager.instance.SetComment("돈이 부족합니다");
            return;
        }
        else
        {
            Gamemanager.instance.player.im.ADItem(itemdata, true);
            Gamemanager.instance.player.im.Money -= itemdata.data.price;
        }
    }


    // 판매 목록 버튼 이벤트
    public void OnClickSell()
    {
        Gamemanager.instance.player.im.ADItem(itemdata, false);
        Gamemanager.instance.player.im.Money += itemdata.data.price;
        if(Gamemanager.instance.player.im.countDic[itemdata.data.itemName] <= 0)
        {
            Debug.Log("삭제");
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
            mc.merchant_slist.Remove(this.itemdata);
            mc.slot_list.Remove(this);
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
