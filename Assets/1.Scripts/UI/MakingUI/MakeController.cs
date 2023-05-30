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

    void Awake()
    {
        btn.onClick.AddListener(() => OnButtonDown());
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

    }
    // �̾ƿ� ������ �̸� �־��ֱ�
    Item GetCompleteItem(InvenItemType type, ItemName name)
    {
        Item item = null;
        ItemDataSetController itemData = Gamemanager.instance.itemController;

        switch (type)
        {
            case InvenItemType.Equipments:
                item = test(itemData.equipments, name);
                break;
            case InvenItemType.Materials:
                item = test(itemData.materilas, name);
                break;
            case InvenItemType.Plants:
                item = test(itemData.plants, name);
                break;
            case InvenItemType.Foods:
                item = test(itemData.foods, name);
                break;
        }
        return item;
    }
    // ������ ������ ������ �̾ƿ���
    Item test(List<Item> list, ItemName name)
    {
        Item item = null;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].data.itemName == name)
            {
                item = list[i];
                break;
            }
        }
        return item;
    }
    // �������� �ϼ�ǰ �̸� ��������
    Item CheckItem()
    {
        Item comPleteItem = null;

        List<JsonData.RecipeJson> recipes = Gamemanager.instance.jsonDataController.recipeData.recipe;

        List<JsonData.RecipeJson> comPletes = new List<JsonData.RecipeJson>();
        ItemName itemName = new ItemName();
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
        return comPleteItem;
    }
    
    public void OnButtonDown()
    {
        if (completedItem.GetItemData() != null)
        {
            // �����ϰ� �κ��� �ִ� ������� ����.
            // ���۴뿡 �ִ� ������ �ʱ�ȭ.
            //
        }
    }
}
