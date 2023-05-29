using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakeController makeController;
    private Item itemData = null;
    private Image itemIcon;

    public bool IsCheck { get; set; }

    void Awake()
    {
        itemIcon = GetComponent<Image>();
        IsCheck = true;
    }
    public void SetItmeData(Item itemdata)
    {
        this.itemData = itemdata;
        //itemIcon.sprite = itemData.data.itemImage;
        makeController.itemDatas.Add(itemData);
    }
    public Item GetItemData()
    {
        return itemData;
    }
    public void DeleteItemData()
    {
        itemData = null;
    }
}
