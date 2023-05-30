using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
public class MakeController : MonoBehaviour
{
    [SerializeField] private List<MakingSlot> slots;
    [SerializeField] private MakingSlot completedItem;
    [SerializeField] private Button btn;

    [HideInInspector] public List<Item> materials = new List<Item>();

    void test()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            for (int j = 0; j < Gamemanager.instance.itemController.recipes.Count; j++)
            {
                //if(Gamemanager.instance.itemController.recipes[j].Contains(slots[i].ItemData.data.itemName))
                //아이템 비교
            }
        }
        
    }
    void Awake()
    {
        btn.onClick.AddListener(() => OnButtonDown());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < Gamemanager.instance.itemController.materilas.Count; i++)
            {
                if (Gamemanager.instance.itemController.materilas[i].data.itemName.ToString() == "Pepper")
                {
                    slots[0].ItemData = Gamemanager.instance.itemController.materilas[i];
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < Gamemanager.instance.itemController.foods.Count; i++)
            {
                if (Gamemanager.instance.itemController.foods[i].data.itemName.ToString() == "Bread")
                {
                    slots[0].ItemData = Gamemanager.instance.itemController.foods[i];
                }
            }
        }
    }
    public void ShowSlot(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.ItemData == null)
            {
                slot.ItemData = item;
                break;
            }
        }
    }
    public void ShowCompletedItem()
    {
        Item item = null;
        for (int i = 0; i < Gamemanager.instance.jsonDataController.recipeData.recipe.Count; i++)
        {
            if (Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].completeitem) == GetCheckItemName())
            {
                item = GetCompleteItem(Enum.Parse<InvenItemType>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].type), GetCheckItemName());
            }
        }
        completedItem.ItemData = item;
    }
    // 1.뽑아올 아이템 이름을 넣어서
    Item GetCompleteItem(InvenItemType type, ItemName name)
    {
        ItemDataSetController itemCont = Gamemanager.instance.itemController;

        List<Item> curItems = new List<Item>();

        Item item = null;

        switch (type)
        {
            case InvenItemType.Equipments:
                curItems = itemCont.equipments.ToList();
                break;

            case InvenItemType.Materials:
                curItems = itemCont.materilas.ToList();
                break;

            case InvenItemType.Plants:
                curItems = itemCont.plants.ToList();
                break;

            case InvenItemType.Foods:
                curItems = itemCont.foods.ToList();
                break;
        }

        for (int i = 0; i < curItems.Count; i++)
        {
            if (curItems[i].data.itemName == name)
            {
                item = curItems[i];
                break;
            }
        }
        return item;
    }
    // 레시피의 완성품 이름 가져오기
    ItemName GetCheckItemName()
    {
        ItemName itemName = new ItemName();
        List<JsonData.RecipeJson> recipes = Gamemanager.instance.jsonDataController.recipeData.recipe;
        List<JsonData.RecipeJson> comPletes = new List<JsonData.RecipeJson>();
        for (int i = 0; i < materials.Count; i++)
        {
            for (int j = 0; j < recipes.Count; j++)
            {
                if (i == 0)
                {
                    if (materials[i].data.itemName.ToString() == recipes[j].material1)
                    {
                        comPletes.Add(recipes[j]);
                    }
                }
                if (i == 1)
                {
                    for (int c = 0; c < comPletes.Count; c++)
                    {
                        if (materials[i].data.itemName.ToString() == comPletes[c].material2)
                        {
                            itemName = Enum.Parse<ItemName>(comPletes[c].completeitem); 
                        }
                    }
                }
            }
        }
        return itemName;
    }
    
    public void OnButtonDown()
    {
        if (completedItem.ItemData != null)
        {
            // 제작하고 인벤에 있는 제작재료 차감.
            for (int i = 0; i < materials.Count; i++)
            {
                Gamemanager.instance.player.inven.DeleteItem(materials[i]);
            }
            // 제작대에 있는 데이터 초기화.
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].ItemData = null;
            }
            Gamemanager.instance.player.inven.AddItem(completedItem.ItemData);
        }
    }
}
