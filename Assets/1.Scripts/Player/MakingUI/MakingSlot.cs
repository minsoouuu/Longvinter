using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakingSlot : MonoBehaviour
{
    [SerializeField] private MakeController makeController;
    private ItemData itemData;
    private Image itemIcon;

    void Awake()
    {
        itemIcon = GetComponent<Image>();
    }
    public void SetItmeData(ItemData itemdata)
    {
        this.itemData = itemdata;
        itemIcon.sprite = this.itemData.itemImage;
        makeController.itemDatas.Add(this.itemData);
    }
    public ItemData GetItemData()
    {
        return itemData;
    }
    public void DeleteItemData()
    {
        itemData = null;
    }
}
