using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject cntTextBG;
    [SerializeField] private TMP_Text cntTxt;
    [SerializeField] private Image icon;
    [SerializeField] private Sprite emptySprite;

    [HideInInspector] public Item item = null;

    public SlotPopup popup;

    private InventoryManager mgr;
    
    public Slot SetData(Item item, InventoryManager mgr)
    {
        this.item = item;
        this.mgr = mgr;

        return this;
    }

    /// <summary>
    /// 아이템을 추가 시킬수 있는 함수
    /// </summary>
    public void SetUI()
    {
        if(item != null)
        {
            if (mgr.countDic.ContainsKey(item.data.itemName))
            {
                icon.sprite = item.data.image;

                if (mgr.countDic[item.data.itemName] > 1)
                {
                    cntTextBG.SetActive(true);
                    cntTxt.text = mgr.countDic[item.data.itemName].ToString();
                }
                else
                {
                    cntTextBG.SetActive(false);
                    cntTxt.text = string.Empty;
                }
            }
            else
            {
                cntTextBG.SetActive(false);
                cntTxt.text = string.Empty;
                Empty();
            }
            // 아이템 갯수가 2개 이상일때만 숫자 표시
        }
    }

    /// <summary>
    /// 아이템을 아무것도 없는 상태로 만드는 함수
    /// </summary>
    public void Empty()
    {
        item = null;
        icon.sprite = emptySprite;
        cntTxt.text = string.Empty;
        cntTextBG.SetActive(false);
    }

    /// <summary>
    /// 아이템사용 1개씩 버리기 버튼
    /// </summary>
    public void OnDelete()
    {
        if (mgr.countDic[item.data.itemName] < 1)
        {
            popup.Enable(false);
        }
        AudioManager.instance.audio.Play();
        string commnet = $"{item.data.itemName} 을 버리시겠습니까?";
        TwoButtonPopUpManager.instance.SetCommnet(commnet, ItemDelete);
    }
    void ItemDelete()
    {
        PocketController po = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(0);
        po.AddItem(item);
        po.transform.SetParent(Gamemanager.instance.parentDropItem);
        po.transform.position = Gamemanager.instance.player.transform.position;
        mgr.ADItem(item, false);

        item = null;
    }

    /// <summary>
    /// 아이템 사용하기
    /// </summary>
    public void OnUse()
    {
        AudioManager.instance.audio.Play();
        string commnet = $"{item.data.itemName} 을 사용하시겠습니까?";
        TwoButtonPopUpManager.instance.SetCommnet(commnet, item.Use);

        popup.Enable(false);
    }

    /// <summary>
    /// 아이템 슬롯 팝업
    /// </summary>
    public void OnPopup()
    {
        mgr.SlotPopupAllOff();
        // 아이템이 아무것도 없을때는 무반응
        if(item != null)
        {
            // 제작대가 켜져 있을경우
            if (mgr.mc != null)
            {
                mgr.mc.SetSlotData(item);
                AudioManager.instance.audio.Play();
            }
            else
            {
                AudioManager.instance.audio.Play();
                popup.Enable(true, item);
            }
        }
    }
}
