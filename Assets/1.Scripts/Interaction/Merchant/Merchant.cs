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

    
    // ���� ��� ��ư �̺�Ʈ
    public void OnClickBuy()
    {
        if (ispop == true)
            return;

        mc.CreateMerchant_s_ItemList(Gamemanager.instance.player.im.curToggle);

        if (Gamemanager.instance.player.im.Money < itemdata.data.price)
        {
            mc.DisableMerchant();
            OneButtonPopUpManager.instance.SetComment("���� �����մϴ�", mc.EnableMerchant);
            return;
        }
        else
        {
            Gamemanager.instance.player.im.ADItem(itemdata, true);
            Gamemanager.instance.player.im.Money -= itemdata.data.price;
        }
    }


    // �Ǹ� ��� ��ư �̺�Ʈ
    public void OnClickSell()
    {
        if(Gamemanager.instance.player.im.countDic[itemdata.data.itemName] <= 1)
        {
            Debug.Log("����");
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
            mc.merchant_slist.Remove(this.itemdata);
            mc.slot_list.Remove(this);
        }
        Gamemanager.instance.player.im.Money += itemdata.data.price;
        Gamemanager.instance.player.im.ADItem(itemdata, false);
    }

    // ������ ����
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
