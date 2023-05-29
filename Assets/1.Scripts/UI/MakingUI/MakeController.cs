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
    [SerializeField] private JsonData recipe;

    [HideInInspector] public List<Item> itemDatas = new List<Item>();

    void Awake()
    {
        btn.onClick.AddListener(() => OnButtonDown());
    }


    Item ChekSlots()
    {
        Item comPleteItem = null;
        int counter = 0;

        List<JsonData.RecipeJson> recipes = new List<JsonData.RecipeJson>();

        string complete = string.Empty;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < recipe.recipeData.recipe.Count; j++)
                {
                    if (slots[i].GetItemData().data.itemName == recipe.recipeData.recipe[j].material1)
                    {
                        recipes.Add(recipe.recipeData.recipe[j]);
                        counter++;
                    }
                }
            }
            else if (i == 1)
            {
                for (int j = 0; j < recipes.Count; j++)
                {
                    if (slots[i].GetItemData().data.itemName == recipes[j].material2) 
                    {
                        complete = recipe.recipeData.recipe[j].completeitem;
                    }
                }
            }
        }

        foreach (var item in items)
        {
            if (item.itemName.ToString() == complete)
            {
                comPleteItem = item;
            }
        }

        recipes.Clear();
        complete = string.Empty;
        counter = 0;

        return comPleteItem;
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
                        itemData = GetItem("Fance");
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
            if (itemName == item.itemName.ToString())
            {
                itemData = item;
            }
        }
        return itemData;
    }
    public void ShowCompletedItem(Item itemData)
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
