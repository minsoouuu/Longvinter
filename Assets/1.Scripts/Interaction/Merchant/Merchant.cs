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

        if (Gamemanager.instance.player.im.Money < itemdata.data.price)
        {
            OneButtonPopUpManager.instance.SetComment("���� �����մϴ�");
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
        Gamemanager.instance.player.im.ADItem(itemdata, false);
        Gamemanager.instance.player.im.Money += itemdata.data.price;
        if(Gamemanager.instance.player.im.countDic[itemdata.data.itemName] <= 0)
        {
            Debug.Log("����");
            Gamemanager.instance.objectPool.ReturnObject(mc.myTypeS, this);
            mc.merchant_slist.Remove(this.itemdata);
            mc.slot_list.Remove(this);
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
