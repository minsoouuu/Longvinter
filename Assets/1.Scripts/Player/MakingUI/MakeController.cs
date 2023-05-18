using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MakeController : MonoBehaviour
{
    [SerializeField] private MakingSlot[] slots;
    [SerializeField] private MakingSlot completedItem;
    [SerializeField] private Button btn;
    [SerializeField] private ItemData[] items;

    [HideInInspector] public List<ItemData> itemDatas = new List<ItemData>();

    void Awake()
    {
        btn.onClick.AddListener(() => OnButtonDown());
    }
    public void Make()
    {
        if (slots[1].GetItemData() != null)
        {
            ItemData item = GetRecipe(slots[0].GetItemData().itemName,
                                      slots[1].GetItemData().itemName);
            ShowCompletedItem(item);
        }
        if (slots[2].GetItemData() != null)
        {
            ItemData item = GetRecipe(slots[0].GetItemData().itemName,
                                      slots[1].GetItemData().itemName,
                                      slots[2].GetItemData().itemName);
            ShowCompletedItem(item);
        }
        if (slots[3].GetItemData() != null)
        {
            ItemData item = GetRecipe(slots[0].GetItemData().itemName,
                                        slots[1].GetItemData().itemName,
                                        slots[2].GetItemData().itemName,
                                        slots[3].GetItemData().itemName);
            ShowCompletedItem(item);
        }
    }
    ItemData GetRecipe(string item1, string item2)
    {
        ItemData item = null;
        CheckRecipe(item1, item2);
        return item;
    }
    ItemData GetRecipe(string item1, string item2, string item3)
    {
        ItemData item = null;

        return item;
    }
    ItemData GetRecipe(string item1, string item2, string item3, string item4)
    {
        ItemData item = null;

        return item;
    }
    ItemData CheckRecipe(string itemName1, string itemName2 )
    {
        ItemData itemData = null;
        switch (itemName1)
        {
            case "Wood":
                switch (itemName2)
                {
                    case "Wood":
                        itemData = GetItem("Wood");
                        break;
                }
                break;
        }
        return itemData;
    }
    ItemData GetItem(string itemName)
    {
        ItemData itemData = null;
        foreach (var item in items)
        {
            if (itemName == item.itemName)
            {
                itemData = item;
            }
        }
        return itemData;
    }
    void ShowCompletedItem(ItemData itemData)
    {
        completedItem.SetItmeData(itemData);
    }
    public void OnButtonDown()
    {
        if (completedItem.GetItemData() != null)
        {
            // 제작하고 인벤에 있는 제작재료 차감.
            // 제작대에 있는 데이터 초기화.
            //
        }
    }
}
