using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    Image image;
    [HideInInspector] public Item item;
    [HideInInspector] public RectTransform rt;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetItemData(Item item)
    {
        image.sprite = item.data.itemImage;
        countText.text = item.Count.ToString();
        this.item = item;
    }
    public void DeleteItem(Sprite nullSprite)
    {
        item = null;
        image.sprite = nullSprite;
        countText.text = string.Empty;
    }
}
