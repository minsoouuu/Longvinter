using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
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
        countText.text = item.Count.ToString();
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
        {
            if (item != null)
            {
                popup.ShowTool(rt.anchoredPosition);
            }
        }
        else if (!slot.isOn)
        {
            popup.HideTool();
        }
        
    }

    
}
