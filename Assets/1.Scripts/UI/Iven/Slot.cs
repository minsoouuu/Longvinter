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
    [HideInInspector] public Item1 item;
    [HideInInspector] public RectTransform rt;

    private void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }
    public void SetItemData(Item1 item)
    {
        image.sprite = item.data.itemImage;
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
            popup.HideTool(rt.anchoredPosition);
        }
    }
}
