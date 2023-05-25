using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public enum ValueType
{
    Item,
    Money
}

public class Inventory : MonoBehaviour
{
    enum TitleType
    {
        equipment,
        material,
        food,
        plant
    }

    [SerializeField] private Item item1;
    [SerializeField] private Item item2;
    [SerializeField] private Transform spawnPoint;

    [HideInInspector] public List<Item> equipments = new List<Item>();
    [HideInInspector] public List<Item> materials = new List<Item>();
    [HideInInspector] public List<Item> foods = new List<Item>();
    [HideInInspector] public List<Item> plants = new List<Item>();
    [HideInInspector] public List<List<Item>> itemss = new List<List<Item>>();
    [HideInInspector] public Sprite nullsprite;

    [SerializeField] private SelectCountController scController;
    [SerializeField] private Button moneyButton;
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private Button closeButton;
    [SerializeField] private ItemPopUp popup;

    public List<Slot> slots;
    private InvenItemType curInvenType = new InvenItemType();

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
        Money = 1000;
        itemss.Add(equipments);
        itemss.Add(materials);
        itemss.Add(foods);
        itemss.Add(plants);
        nullsprite = Resources.Load<Sprite>("HONETi/mobile_cartoon_GUI/GUI Elements/Textfield/text_background_big");
        moneyButton.onClick.AddListener(() => OnButtonDownMoneyEvent());
        closeButton.onClick.AddListener(() => OnButtonDownClose());
    }
    private void Start()
    {
        SelectCountController select = Instantiate(scController, spawnPoint);
        select.gameObject.SetActive(false);
        scController = select;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            item1.Init();
            AddItem(item1);
            Debug.Log("?????? ????");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            item2.Init();
            AddItem(item2);
            Debug.Log("?????? ????");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            DeleteItem(item1);
        }
    }

    void OnButtonDownClose()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void OpenInventorry()
    {
        ShowItem(itemss[0]);
        titleText.text = $"{(TitleType)(0)}";
        curInvenType = (InvenItemType)(0);
        toggles[0].isOn = true;
    }
    public void OnToggleSet(int index)
    {
        if (toggles[index].isOn)
        {
            ShowItem(itemss[index]);
            titleText.text = $"{(TitleType)(index)}";
            curInvenType = (InvenItemType)(index);
        }
    }
    public void AddItem(Item item)
    {
        if (slots[slots.Count -1].item != null)
            return;

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
        ShowItem(curItems);
    }
    public void DeleteItem(Item item)
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
                            it.Count -= 1;
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
                            it.Count -= 1;
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
                            it.Count -= 1;
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
                            it.Count -= 1;
                            break;
                        }
                    }
                }
                curItems = plants.ToList();
                break;
        }
        ShowItem(curItems);
    }
    void OnButtonDownMoneyEvent()
    {
        Vector3 moneyPos = moneyButton.transform.position;
        if (!scController.gameObject.activeSelf)
        {
            scController.transform.position = moneyPos - new Vector3(0, 10, 0);
            scController.SetValueType(ValueType.Money);
            scController.gameObject.SetActive(true);
        }
        Debug.Log("?? ??????");
    }
    
    void ShowItem(List<Item> items)
    {
        for (int i = 0; i < slots.Count; i++ )
        {
            if (slots[i].item != null)
            {
                slots[i].DeleteItem(nullsprite);
            }
        }
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].SetItemData(items[i]);
            slots[i].SetItemPopup(popup);
        }
    }
    
}
