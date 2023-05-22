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
    [HideInInspector] public List<Slot> slots;


    private void Start()
    {
        
    }

    public void OnToggleSet(Toggle toggle)
    {

    }

    public void SetItemData(Item item)
    {
        /*
        switch (item.data.itemType)
        {
            case InvenItemType.Equipments:
                equipments.Add(item);
                break;
            case InvenItemType.Materials:
                materials.Add(item);
                break;
            case InvenItemType.Foods:
                foods.Add(item);
                break;
            case InvenItemType.plants:
                plants.Add(item);
                break;
        }
        */
    }

    void ShowItem(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            // 슬롯 아이템 셋팅 함수.
            // 슬롯에 아이템 데이터 세팅 하기
            //slots[i]. = items[i];
        }
    }
}
