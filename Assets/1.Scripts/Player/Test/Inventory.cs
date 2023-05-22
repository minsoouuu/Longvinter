using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [SerializeField] Item item1;
    [SerializeField] Item item2;


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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            item1.Init();
            SetItemData(item1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            item2.Init();
            SetItemData(item2);
        }
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
        List<Item> curItems = new List<Item>();
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
                curItems = equipments.ToList();
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
                curItems = materials.ToList();
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
                curItems = foods.ToList();
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
                curItems = plants.ToList();
                break;

        }
        ShowItem(curItems);
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
