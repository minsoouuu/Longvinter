using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class Inventory : MonoBehaviour
{
    enum TitleType
    {
        장비,
        재료,
        음식,
        설치
    }

    [SerializeField] Item item1;
    [SerializeField] Item item2;

    [HideInInspector] public List<Item> equipments = new List<Item>();
    [HideInInspector] public List<Item> materials = new List<Item>();
    [HideInInspector] public List<Item> foods = new List<Item>();
    [HideInInspector] public List<Item> plants = new List<Item>();

    [SerializeField] private SelectCountController scController;
    [SerializeField] private Button moneyButton;
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text titleText;

    [HideInInspector] public Sprite nullsprite;
    private List<List<Item>> itemss = new List<List<Item>>();

    public List<Slot> slots;


    private int money;
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            moneyText.text = Money.ToString();
        }
    }
    private void Awake()
    {
        itemss.Add(equipments);
        itemss.Add(materials);
        itemss.Add(foods);
        itemss.Add(plants);
        nullsprite = Resources.Load<Sprite>("HONETi/mobile_cartoon_GUI/GUI Elements/Textfield/text_background_big");
        moneyButton.onClick.AddListener(() => OnButtonDownMoneyEvent());
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            item1.Init();
            SetItemData(item1);
            Debug.Log("아이템 생성");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            item2.Init();
            SetItemData(item2);
            Debug.Log("아이템 생성");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            DeductionItem(item1);
            Debug.Log("아이템 생성");
        }
    }
    public void OnToggleSet(int index)
    {
        if (toggles[index].isOn)
        {
            titleText.text = $"{(TitleType)(index)}";
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
                            break;
                        }
                    }
                }
                curItems = equipments;
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
                            break;
                        }
                    }
                }
                curItems = materials;
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
                            break;
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
                            break;  
                        }
                    }
                }
                curItems = plants.ToList();
                break;
        }
    }

    void OnButtonDownMoneyEvent()
    {
        // 돈 버리기
    }

    bool CheckSlotItem(Item item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item.data.itemType == item.data.itemType)
            {
                slots[i].DeleteItem(nullsprite);
                return true;
            }
        }
        return false;
    }

    Slot GetSlot(Item item)
    {
        Slot slot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item.data.itemType == item.data.itemType)
            {
                slot = slots[i];
            }
        }
        return slot;
    }

    public void DeductionItem(Item item)
    {
        for (int i = 0; i < itemss.Count; i++)
        {
            for (int j = 0; j < itemss[i].Count; j++)
            {
                foreach (var it in itemss[i])
                {
                    if (it.data.itemName == item.data.itemName)
                    {
                        it.Count -= 1;
                        if (it.Count <= 0)
                        {
                            if (CheckSlotItem(item) == true)
                            {
                                GetSlot(item).DeleteItem(nullsprite);
                            }
                        }
                    }
                }
            }
        }
        return;
        List<Item> curItems = new List<Item>();
        switch (item.data.itemType)
        {
            case InvenItemType.Equipments:
                curItems = equipments;
                break;
            case InvenItemType.Materials:
                curItems = materials;
                break;
            case InvenItemType.Foods:
                curItems = foods;
                break;
            case InvenItemType.Plants:
                curItems = plants;
                break;
        }

        foreach (var it in curItems)
        {
            if (!curItems.Contains(item))
                return;
            if (it.data.itemName == item.data.itemName)
            {
                it.Count -= 1;
                if (it.Count <= 0)
                {

                }
            }
        }
    }
    void ShowItem(List<Item> items)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item != null)
            {
                //slots[i].DeleteItem();
            }
        }
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].SetItemData(items[i]);
        }
    }
}
