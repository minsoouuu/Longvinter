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
    [HideInInspector] public bool ispop = false;

    
    // 구매 목록 버튼 이벤트
    public void OnClickBuy()
    {
        if (ispop == true)
            return;

        mc.CreateMerchant_s_ItemList(Gamemanager.instance.player.im.curToggle);

        if (Gamemanager.instance.player.im.Money < itemdata.data.price)
        {
            mc.DisableMerchant();
            OneButtonPopUpManager.instance.SetComment("돈이 부족합니다", mc.EnableMerchant);
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
        if(Gamemanager.instance.player.im.countDic[itemdata.data.itemName] <= 1)
        {
            Debug.Log("삭제");
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
            mc.merchant_slist.Remove(this.itemdata);
            mc.slot_list.Remove(this);
        }
        Gamemanager.instance.player.im.Money += itemdata.data.price;
        Gamemanager.instance.player.im.ADItem(itemdata, false);
    }

    // 데이터 세팅
    public void Setdata(Item itemdata)
    {
        this.itemdata = itemdata;
        image.sprite = itemdata.data.image;
        mk.text = itemdata.data.price.ToString();
    }
    public void SetIsPop()
    {
        if (ispop == true)
        {
            ispop = false;
        }
    }
    
}
