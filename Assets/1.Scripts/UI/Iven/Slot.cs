using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    /* 코드 재정의
    [SerializeField] TMP_Text countText;
    [HideInInspector] public Item item;
    [HideInInspector] public RectTransform rt;
    public Toggle slot;
    private Image image;
    private InvenItemClick popup;

    private void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        slot.onValueChanged.AddListener(delegate { ToggleOnOff(); });
    }
    public void SetItemData(Item item)
    {
        image.sprite = item.data.image;
        countText.text = item.data.count.ToString();
        this.item = item;
    }
    public void SetItemPopup(InvenItemClick popup)
    {
        this.popup = popup;
    }
    public void DeleteItem(Sprite nullSprite)
    {
        item = null;
        image.sprite = nullSprite;
        countText.text = string.Empty;
    }
    public void ToggleOnOff()
    {
        if (slot.isOn)
            if (item != null)
                popup.ShowTool(rt.anchoredPosition);
        else if (!slot.isOn)
            popup.HideTool();
    }
    */

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
            cntTxt.text = item.data.count.ToString();
            icon.sprite = item.data.image;

            if(item.data.count <= 0)
                Empty();
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
    }

    /// <summary>
    /// 아이템사용 1개씩 버리기 버튼
    /// </summary>
    public void OnDelete()
    {
        mgr.ADItem(item, false);
    }

    public void OnPopup()
    {
        Gamemanager.instance.player.im.SlotPopupAllOff();
        popup.Enable(true);
    }
}
