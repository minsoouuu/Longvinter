using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text countText;
    private Image image;
    private ItemPopUp popup;
    [HideInInspector] public Item item;
    [HideInInspector] public RectTransform rt;

    private void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }
    public void SetItemData(Item item)
    {
        image.sprite = item.data.image;
        countText.text = item.Count.ToString();
        this.item = item;
    }
    public void SetItemPopup(ItemPopUp popup)
    {
        this.popup = popup;
    }
    public void DeleteItem(Sprite nullSprite)
    {
        item = null;
        image.sprite = nullSprite;
        countText.text = string.Empty;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            popup.ShowTool(rt.anchoredPosition);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            if (popup == true)
            {
                //만약 팝업이 켜진 상태라면 팝업 위까지 커서 영역 확대해서 팝업 클릭 가능하도록 하기

            }
            popup.HideTool();
        }
    }
}
