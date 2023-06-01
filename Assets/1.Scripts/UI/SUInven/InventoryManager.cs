using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    public enum TitleType
    {
        Equipment,
        Material,
        Food,
        Plant
    }

    [SerializeField] private Transform slotParent;
    [SerializeField] private Toggle[] toggles;

    private Dictionary<TitleType, List<Item>> itemDic = new Dictionary<TitleType, List<Item>>();

    List<Slot> slots = new List<Slot>();

    void Start()
    {
        itemDic.Add(TitleType.Equipment, new List<Item>());
        itemDic.Add(TitleType.Material, new List<Item>());
        itemDic.Add(TitleType.Food, new List<Item>());
        itemDic.Add(TitleType.Plant, new List<Item>());

        // 슬롯이 늘엇날 경우를 대비해 코드로 작성
        if (slots.Count == 0)
        {
            for (int i = 0; i < slotParent.childCount; i++)
            {
                slots.Add(slotParent.GetChild(i).GetComponent<Slot>());
            }
        }
    }

    private void Update()
    {
        ItemDataSetController ic = Gamemanager.instance.itemController;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            int rand = Random.Range(0, 2);
            AddItem(ic.equipments[rand]);
            Debug.Log("장비 아이템 추가");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            int rand = Random.Range(0, ic.materilas.Count);
            AddItem(ic.materilas[rand]);
            Debug.Log("재료 아이템 추가");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            int rand = Random.Range(0, ic.foods.Count);
            AddItem(ic.foods[rand]);
            Debug.Log("음식 아이템 추가");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            int rand = Random.Range(0, ic.plants.Count);
            AddItem(ic.plants[rand]);
            Debug.Log("설치 아이템 추가");
        }
    }

    /// <summary>
    /// 해당 토글 아이템을 찾아 인벤토리 아이템 변경
    /// </summary>
    public void OnTabChange(Toggle toggle)
    {
        Toggle curToggle = null;
        foreach (Toggle item in toggles)
        {
            if(item == toggle && toggle.isOn)
            {
                curToggle = item;
                SlotClear();
                SlotChangeItem(EnumUtil<TitleType>.Parse(item.name));
                break;
            }
        }

        if(curToggle != null)
        {

        }
    }

    public void OnSort()
    {

    }

    /// <summary>
    /// 아이템 추가
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        TitleType key = item.data.itemType == InvenItemType.Equipments ? TitleType.Equipment :
                     item.data.itemType == InvenItemType.Materials ? TitleType.Material :
                     item.data.itemType == InvenItemType.Foods ? TitleType.Food :
                     item.data.itemType == InvenItemType.Plants ? TitleType.Plant : TitleType.Equipment;

        if(!itemDic[key].Contains(item))
        {
            itemDic[key].Add(item);
        }
        else
        {
            foreach (var dicItem in itemDic[key])
            {
                if (item.data.itemName == dicItem.data.itemName)
                {
                    dicItem.data.count += 1;
                    break;
                }
            }
        }

        // 빈슬롯 찾기
        foreach (var slot in slots)
        {
            if(slot.item == item || slot.item == null)
            {
                slot.SetData(item).Add();
                break;
            }
        }
    }

    /// <summary>
    /// 인벤토리가 가지고 있는 슬롯들 전부 빈화면으로
    /// </summary>
    void SlotClear()
    {
        foreach (var slot in slots)
        {
            slot.Empty();
        }
    }

    /// <summary>
    /// 탭 선택시 해당탭에 관련된 아이템 보여줌.
    /// </summary>
    void SlotChangeItem(TitleType tapType)
    {
        if(itemDic.ContainsKey(tapType))
        {
            for (int i = 0; i < itemDic[tapType].Count; i++)
            {
                foreach (var slot in slots)
                {
                    if (slot.item == null)
                    {
                        slot.SetData(itemDic[tapType][i]).Add();
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 슬롯에 켜져 있는 팝업을 전부 끈다.
    /// </summary>
    public void SlotPopupAllOff()
    {
        if(slots.Count != 0)
        {
            foreach (var item in slots)
            {
                item.popup.Enable(false);
            }
        }
    }
}
