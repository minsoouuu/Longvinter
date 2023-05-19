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
    [SerializeField] private Item[] items;

    [HideInInspector] public List<Item> itemDatas = new List<Item>();

    void Awake()
    {
        btn.onClick.AddListener(() => OnButtonDown());
    }
    public void Make()
    {
        if (slots[1].GetItemData() != null)
        {
            Item item = GetRecipe(slots[0].GetItemData().data.itemName,
                                      slots[1].GetItemData().data.itemName);
            ShowCompletedItem(item);
        }
        if (slots[2].GetItemData() != null)
        {
            Item item = GetRecipe(slots[0].GetItemData().data.itemName,
                                      slots[1].GetItemData().data.itemName,
                                      slots[2].GetItemData().data.itemName);
            ShowCompletedItem(item);
        }
        if (slots[3].GetItemData() != null)
        {
            Item item = GetRecipe(slots[0].GetItemData().data.itemName,
                                        slots[1].GetItemData().data.itemName,
                                        slots[2].GetItemData().data.itemName,
                                        slots[3].GetItemData().data.itemName);
            ShowCompletedItem(item);
        }
    }
    Item GetRecipe(string item1, string item2)
    {
        Item item = null;
        CheckRecipe(item1, item2);
        return item;
    }
    Item GetRecipe(string item1, string item2, string item3)
    {
        Item item = null;

        return item;
    }
    Item GetRecipe(string item1, string item2, string item3, string item4)
    {
        Item item = null;

        return item;
    }
    Item CheckRecipe(string itemName1, string itemName2 )
    {
        Item itemData = null;
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
    Item GetItem(string itemName)
    {
        Item itemData = null;
        foreach (var item in items)
        {
            if (itemName == item.data.itemName)
            {
                itemData = item;
            }
        }
        return itemData;
    }
    void ShowCompletedItem(Item itemData)
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
