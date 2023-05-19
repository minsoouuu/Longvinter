using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakeController makeController;
    private Item itemData;
    private Image itemIcon;

    void Awake()
    {
        itemIcon = GetComponent<Image>();
    }
    public void SetItmeData(Item itemdata)
    {
        this.itemData = itemdata;
        itemIcon.sprite = this.itemData.data.itemImage;
        makeController.itemDatas.Add(this.itemData);
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
