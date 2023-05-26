using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPoolSystem : MonoBehaviour
{
    [SerializeField] private List<Merchant> slotPrefabs;
    [SerializeField] private List<Item1> itemPrefabs;
    [SerializeField] private List<House> housePrefabs;
    [SerializeField] private List<Monster> monsterPrefabs;

    private Dictionary<ObjectType, Queue<Merchant>> objectPools = new Dictionary<ObjectType, Queue<Merchant>>();
    private Dictionary<ItemName, Queue<Item1>> itemPools = new Dictionary<ItemName, Queue<Item1>>();
    private Dictionary<MonsterType, Queue<Monster>> monsterPools = new Dictionary<MonsterType, Queue<Monster>>();
    private Dictionary<HouseType, Queue<House>> housePools = new Dictionary<HouseType, Queue<House>>();


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
            Enum.GetValues(typeof(HouseType)).Length
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
                        itemPools[(ItemName)(j)] = new Queue<Item1>();
                        break;
                    case 2:
                        monsterPools[(MonsterType)(j)] = new Queue<Monster>();
                        break;
                    case 3:
                        housePools[(HouseType)(j)] = new Queue<House>();
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
    public void ReturnObject(ItemName type, Item1 obj)
    {
        obj.gameObject.SetActive(false);
        itemPools[type].Enqueue(obj);
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
    public Monster GetObjectOfObjectPooling(MonsterType type)
    {
        Monster obj = null;

        if (monsterPools[type].Count != 0)
        {
            obj = monsterPools[type].Dequeue();
        }
        else
        {
            foreach (var monster in monsterPrefabs)
            {
                if (monster.monsterData.monsterType == type)
                {

                    obj = Instantiate(monster);
                    break;
                }
            }
        }
        obj.gameObject.SetActive(true);
        return obj;
    }
    public Item1 GetObjectOfObjectPooling(ItemName type)
    {
        Item1 obj = null;

        if (itemPools[type].Count != 0)
        {
            obj = itemPools[type].Dequeue();
        }
        else
        {
        }

        obj.gameObject.SetActive(true);
        return obj;
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
