using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    enum TitleType
    {
        Equipment,
        Material,
        Food,
        Plant
    }

    [SerializeField] private Transform slotParent;
    [SerializeField] private Toggle[] toggles;

    [SerializeField] private TMPro.TMP_Text title;

    private Dictionary<TitleType, List<Item>> itemDic = new Dictionary<TitleType, List<Item>>();
    private List<Slot> slots = new List<Slot>();

    private Toggle curToggle = null;

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

        curToggle = toggles[0];
        title.text = GetTitleString(toggles[0].name);
    }

    private void Update()
    {
        ItemDataSetController ic = Gamemanager.instance.itemController;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("장비 아이템 추가");
            int rand = Random.Range(0, ic.equipments.Count);
            ADItem(isAdd: true, item: ic.equipments[rand]);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            /*
            Debug.Log("재료 아이템 추가");
            int rand = Random.Range(0, ic.materilas.Count);
            ADItem(isAdd: true, item: ic.materilas[rand]);
            

            Debug.Log("장비 아이템 추가");
            int rand = Random.Range(0, ic.equipments.Count);
            ADItem(isAdd: false, item: ic.equipments[rand]);
            */

            MakingController mc = FindObjectOfType<MakingController>();
            mc.Ison = !mc.Ison;
            Debug.Log(mc.Ison ? "제작대 On" : "제작대 Off");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Debug.Log("음식 아이템 추가");
            int rand = Random.Range(0, ic.foods.Count);
            ADItem(isAdd: true, item: ic.foods[rand]);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Debug.Log("설치 아이템 추가");
            int rand = Random.Range(0, ic.plants.Count);
            ADItem(isAdd: true, item:ic.plants[rand]);
        }
    }

    /// <summary>
    /// 해당 토글 아이템을 찾아 인벤토리 아이템 변경
    /// </summary>
    public void OnTabChange(Toggle toggle)
    {
        // 카테고리에 맞게 해당 아이템들을 보여준다.
        foreach (Toggle t in toggles)
        {
            if(t == toggle && toggle.isOn)
            {
                curToggle = t;
                SlotClear();
                SlotChangeItem(EnumUtil<TitleType>.Parse(t.name));

                title.text = GetTitleString(t.name);
                break;
            }
        }
    }

    /// <summary>
    /// 해당 탭에서만 정렬
    /// </summary>
    public void OnSort()
    {
        TitleType curKey = TitleType.Equipment;
        for (int i = 0; i < toggles.Length; i++)
        {
            if(curToggle == toggles[i])
            {
                curKey = (TitleType)i;
                itemDic[curKey].Sort((a, b) => a.data.serial.CompareTo(b.data.serial));
                break;
            }
        }

        int count = 0;
        foreach (var item in itemDic[curKey])
        {
            slots[count].Empty();
            slots[count].item = item;
            count++;
        }
            
        foreach (var slot in slots)
            slot.SetUI();
    }

    /// <summary>
    /// 슬롯에서 삭제 시킬시 메인도 함께 지워야 한다. 
    /// </summary>
    public void DeleteData(Item item)
    {
        itemDic[GetTitleType(item)].Remove(item);
    }

    /// <summary>
    /// 아아템 변경
    /// </summary>
    /// <param name="item"> 데이터 </param>
    /// <param name="isAdd"> 추가 할지, 삭제 할지 </param>
    public void ADItem(Item item, bool isAdd)
    {
        TitleType key = GetTitleType(item);

        if (!itemDic[key].Contains(item) && isAdd)
        {
            // 인벤토리 공간 체크
            bool isAddCheck = false;

            foreach (var slot in slots)
            {
                if(slot.item == null)
                {
                    isAddCheck = true;
                    break;
                }
            }

            if (!isAddCheck)
            {
                // 팝업 (인벤토리가 부족하여 습득하지 못했습니다.)
                Debug.Log("인벤토리 공간이 부족으로 습득실패");
                return;
            }

            itemDic[key].Add(item);
        }
        else
        {
            foreach (var dicItem in itemDic[key])
            {
                Debug.Log($"Item Name Check : {item.data.itemName}, {dicItem.data.itemName}");
                if (item.data.itemName == dicItem.data.itemName)
                {
                    if(isAdd)
                        dicItem.data.count++;
                    else
                    {
                        dicItem.data.count--;
                        if (dicItem.data.count < 0)
                            DeleteData(dicItem);
                    }
                    break;
                }
            }
        }

        // 현재 선택된 토글 아이템만 사용자에게 보여주기
        // 아이템을 추가 했는지 안했는지 체크
        if(curToggle != null && EnumUtil<TitleType>.Parse(curToggle.name) == key)
        {
            foreach (var slot in slots)
            {
                if (isAdd && slot.item == null)
                {
                    slot.SetData(item, this).SetUI();
                    break;
                }
                else if(slot.item != null && slot.item == item)
                {
                    slot.SetData(item, this).SetUI();
                    break;
                }
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
                        slot.SetData(itemDic[tapType][i], this).SetUI();
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

    TitleType GetTitleType(Item item)
    {
        return item.data.itemType == InvenItemType.Equipments ? TitleType.Equipment :
                     item.data.itemType == InvenItemType.Materials ? TitleType.Material :
                     item.data.itemType == InvenItemType.Foods ? TitleType.Food :
                     item.data.itemType == InvenItemType.Plants ? TitleType.Plant : TitleType.Equipment;
    }

    string GetTitleString(string toggleName)
    {
        return toggleName.Equals("Equipment") ? "장비" :
                     toggleName.Equals("Material") ? "재료" :
                     toggleName.Equals("Food") ? "음식" :
                     toggleName.Equals("Plant") ? "설치 재료" : "타이틀 에러";
    }
}
