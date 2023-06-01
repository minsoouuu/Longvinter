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

        // ������ �þ��� ��츦 ����� �ڵ�� �ۼ�
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
            Debug.Log("��� ������ �߰�");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            int rand = Random.Range(0, ic.materilas.Count);
            AddItem(ic.materilas[rand]);
            Debug.Log("��� ������ �߰�");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            int rand = Random.Range(0, ic.foods.Count);
            AddItem(ic.foods[rand]);
            Debug.Log("���� ������ �߰�");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            int rand = Random.Range(0, ic.plants.Count);
            AddItem(ic.plants[rand]);
            Debug.Log("��ġ ������ �߰�");
        }
    }

    /// <summary>
    /// �ش� ��� �������� ã�� �κ��丮 ������ ����
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
    /// ������ �߰�
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

        // �󽽷� ã��
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
    /// �κ��丮�� ������ �ִ� ���Ե� ���� ��ȭ������
    /// </summary>
    void SlotClear()
    {
        foreach (var slot in slots)
        {
            slot.Empty();
        }
    }

    /// <summary>
    /// �� ���ý� �ش��ǿ� ���õ� ������ ������.
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
    /// ���Կ� ���� �ִ� �˾��� ���� ����.
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
