using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakeController makeController;
    private Item1 itemData = null;
    private Image itemIcon;

    public bool IsCheck { get; set; }

    void Awake()
    {
        itemIcon = GetComponent<Image>();
        IsCheck = true;
    }
    public void SetItmeData(Item1 itemdata)
    {
        this.itemData = itemdata;
        itemIcon.sprite = itemData.data.itemImage;
        makeController.itemDatas.Add(itemData);
    }
    public Item1 GetItemData()
    {
        return itemData;
    }
    public void DeleteItemData()
    {
        itemData = null;
    }
}
