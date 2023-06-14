using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPoolSystem : MonoBehaviour
{
    [SerializeField] private List<Merchant> slotPrefabs;

    private Dictionary<ObjectType, Queue<Merchant>> objectPools = new Dictionary<ObjectType, Queue<Merchant>>();
    private Dictionary<ItemName, Queue<Item>> itemPools = new Dictionary<ItemName, Queue<Item>>();
    private Dictionary<MonsterType, Queue<Monster>> monsterPools = new Dictionary<MonsterType, Queue<Monster>>();
    private Dictionary<HouseType, Queue<PlaceableObject>> housePools = new Dictionary<HouseType, Queue<PlaceableObject>>();
    private Dictionary<PopType, Queue<PopUp>> popPools = new Dictionary<PopType, Queue<PopUp>>();
    private Queue<FishingController> fishingPools = new Queue<FishingController>();
    private Queue<PocketController> pocketPools = new Queue<PocketController>();

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
                        housePools[(HouseType)(j)] = new Queue<PlaceableObject>();
                        break;
                    case 4:
                        popPools[(PopType)(j)] = new Queue<PopUp>();
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
        obj.transform.SetParent(transform);
        monsterPools[type].Enqueue(obj);
    }
    public void ReturnObject(HouseType type, PlaceableObject obj)
    {
        obj.gameObject.SetActive(false);
        housePools[type].Enqueue(obj);
    }
    public void ReturnObject(PopType type, PopUp obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        popPools[type].Enqueue(obj);
    }
    public void ReturnObject(FishingController obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        fishingPools.Enqueue(obj);
    }
    public void ReturnObject(PocketController obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        pocketPools.Enqueue(obj);
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
    public FishingController GetObjectOfObjectPooling(string name)
    {
        FishingController obj = null;

        if (fishingPools.Count != 0)
        {
            obj = fishingPools.Dequeue();
        }
        else
        {
            string path = $"Fishing/{name}";
            FishingController fishing = Resources.Load<FishingController>(path);
            obj = Instantiate(fishing);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    // 포켓 생성갯수를 정해주기 위한 int 인자값 나중에.....
    public PocketController GetObjectOfObjectPooling(int num)
    {
        PocketController obj = null;

        if (pocketPools.Count != 0)
        {
            obj = pocketPools.Dequeue();
        }
        else
        {
            string path = $"Pocket/PocketPrefab";
            PocketController pocket = Resources.Load<PocketController>(path);
            obj = Instantiate(pocket);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    public PopUp GetObjectOfObjectPooling(PopType type)
    {
        PopUp obj = null;
        if (popPools[type].Count != 0)
        {
            obj = popPools[type].Dequeue();
        }
        else
        {
            string path = $"PopupPrefabs/{type}";
            PopUp toastPopUp = Resources.Load<PopUp>(path);
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
    public PlaceableObject GetObjectOfObjectPooling(HouseType type)
    {
        PlaceableObject obj = null;

        if (housePools[type].Count != 0)
        {
            obj = housePools[type].Dequeue();
        }
        else
        {
            string path = $"House/{type}";
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
}
