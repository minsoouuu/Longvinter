using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPoolSystem : MonoBehaviour
{
    [SerializeField] private List<Merchant> slotPrefabs;
    [SerializeField] private List<Item> itemPrefabs;
    [SerializeField] private List<House> housePrefabs;
    [SerializeField] private List<Monster> monsterPrefabs;

    private Dictionary<ObjectType, Queue<Merchant>> objectPools = new Dictionary<ObjectType, Queue<Merchant>>();
    private Dictionary<ItemName, Queue<Item>> itemPools = new Dictionary<ItemName, Queue<Item>>();
    private Dictionary<MonsterType, Queue<Monster>> monsterPools = new Dictionary<MonsterType, Queue<Monster>>();
    private Dictionary<HouseType, Queue<House>> housePools = new Dictionary<HouseType, Queue<House>>();
    private Dictionary<PopType, Queue<ToastPopUp>> popPools = new Dictionary<PopType, Queue<ToastPopUp>>();

    private void Awake()
    {
        DataSetting();
    }
    void DataSetting()
    {
        int[] typeCount = new int[]
        {
            Enum.GetValues(typeof(ObjectType)).Length,
            Enum.GetValues(typeof(ItemName)).Length,
            Enum.GetValues(typeof(MonsterType)).Length,
            Enum.GetValues(typeof(HouseType)).Length,
            Enum.GetValues(typeof(PopType)).Length
        };
        for (int i = 0; i < typeCount.Length; i++)
        {
            for (int j = 0; j < typeCount[i]; j++)
            {
                switch (i)
                {
                    case 0:
                        objectPools[(ObjectType)(j)] = new Queue<Merchant>();
                        break;
                    case 1:
                        itemPools[(ItemName)(j)] = new Queue<Item>();
                        break;
                    case 2:
                        monsterPools[(MonsterType)(j)] = new Queue<Monster>();
                        break;
                    case 3:
                        housePools[(HouseType)(j)] = new Queue<House>();
                        break;
                    case 4:
                        popPools[(PopType)(j)] = new Queue<ToastPopUp>();
                        break;
                }
            }
        }
    }
    public void ReturnObject(ObjectType objectType, Merchant obj)
    {
        obj.gameObject.SetActive(false);
        objectPools[objectType].Enqueue(obj);
    }
    public void ReturnObject(ItemName name, Item obj)
    {
        obj.gameObject.SetActive(false);
        itemPools[name].Enqueue(obj);
    }
    public void ReturnObject(MonsterType type, Monster obj)
    {
        obj.gameObject.SetActive(false);
        monsterPools[type].Enqueue(obj);
    }
    public void ReturnObject(HouseType type, House obj)
    {
        obj.gameObject.SetActive(false);
        housePools[type].Enqueue(obj);
    }
    public void ReturnObject(PopType type, ToastPopUp obj)
    {
        obj.gameObject.SetActive(false);
        popPools[type].Enqueue(obj);
        obj.transform.SetParent(transform);
    }

    // true - Buy, false - Sell
    public Merchant GetObjectOfObjectPooling(ObjectType objectType, bool a)
    {
        Merchant obj = null;

        if (objectPools[objectType].Count != 0)
        {
            obj = objectPools[objectType].Dequeue();
        }
        else
        {
            if (a)
            {
                obj = Instantiate(slotPrefabs[0]);
            }
            else
            {
                obj = Instantiate(slotPrefabs[1]);
            }
            
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    public ToastPopUp GetObjectOfObjectPooling(PopType type)
    {
        ToastPopUp obj = null;

        if (popPools[type].Count != 0)
        {
            obj = popPools[type].Dequeue();
        }
        else
        {
            string path = $"PopupPrefabs/{type}";
            ToastPopUp toastPopUp = Resources.Load<ToastPopUp>(path);
            obj = Instantiate(toastPopUp);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    public Monster GetObjectOfObjectPooling(MonsterType type)
    {
        Monster obj = null;

        if (monsterPools[type].Count != 0)
        {
            obj = monsterPools[type].Dequeue();
        }
        else
        {
            string path = $"Monster/{type}";
            Monster monster = Resources.Load<Monster>(path);
            obj = Instantiate(monster);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    public Item GetObjectOfObjectPooling(InvenItemType itemType,ItemName name)
    {
        Item obj = null;

        if (itemPools[name].Count != 0)
        {
            obj = itemPools[name].Dequeue();
            obj.gameObject.SetActive(true);
        }
        else
        {
            switch (itemType)
            {
                case InvenItemType.Equipments:
                    obj = Instantiate(CreateItem(Gamemanager.instance.itemController.equipments, name));
                    break;

                case InvenItemType.Materials:
                    obj = Instantiate(CreateItem(Gamemanager.instance.itemController.materilas, name));
                    break;

                case InvenItemType.Foods:
                    obj = Instantiate(CreateItem(Gamemanager.instance.itemController.foods, name));
                    break;

                case InvenItemType.Plants:
                    obj = Instantiate(CreateItem(Gamemanager.instance.itemController.plants, name));
                    break;
            }
        }
        return obj;
    }
    Item CreateItem(List<Item> items, ItemName name)
    {
        Item item = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].data.itemName == name)
            {
                item = items[i];
                break;
            }
        }
        return item;
    }
    public House GetObjectOfObjectPooling(HouseType type)
    {
        House obj = null;

        if (housePools[type].Count != 0)
        {
            obj = housePools[type].Dequeue();
        }
        else
        {
        }

        obj.gameObject.SetActive(true);
        return obj;
    }
}
