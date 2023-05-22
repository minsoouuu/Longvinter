using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [HideInInspector] public List<Item> equipments = new List<Item>();
    [HideInInspector] public List<Item> materials = new List<Item>();
    [HideInInspector] public List<Item> foods = new List<Item>();
    [HideInInspector] public List<Item> plants = new List<Item>();

    List<List<Item>> itemss = new List<List<Item>>();

    [SerializeField] private Toggle[] toggles;

    public List<Slot> slots;

    private void Start()
    {
        itemss.Add(equipments);
        itemss.Add(materials);
        itemss.Add(foods);
        itemss.Add(plants);

    }

    public void OnToggleSet(int index)
    {
        if (toggles[index].isOn)
        {
            ShowItem(itemss[index]);
        }
    }

    public void SetItemData(Item item)
    {
        switch (item.data.itemType)
        {
            case InvenItemType.Equipments:
                if (!equipments.Contains(item))
                {
                    equipments.Add(item);
                }
                else
                {
                    foreach (var it in equipments)
                    {
                        if (item.data.itemName == it.data.itemName)
                        {
                            it.Count += 1;
                        }
                    }
                }
                break;
            case InvenItemType.Materials:
                if (!materials.Contains(item))
                {
                    materials.Add(item);
                }
                else
                {
                    foreach (var it in materials)
                    {
                        if (item.data.itemName == it.data.itemName)
                        {
                            it.Count += 1;
                        }
                    }
                }
                break;
            case InvenItemType.Foods:

                if (!foods.Contains(item))
                {
                    foods.Add(item);
                }
                else
                {
                    foreach (var it in foods)
                    {
                        if (item.data.itemName == it.data.itemName)
                        {
                            it.Count += 1;
                        }
                    }
                }
                break;
            case InvenItemType.Plants:
                if (!plants.Contains(item))
                {
                    plants.Add(item);
                }
                else
                {
                    foreach (var it in plants)
                    {
                        if (item.data.itemName == it.data.itemName)
                        {
                            it.Count += 1;
                        }
                    }
                }
                break;
        }
    }

    void ShowItem(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            // 슬롯 아이템 셋팅 함수.

            // 슬롯에 아이템 데이터 세팅 하기

            slots[i].SetItemData(items[i]);
        }
    }
}
