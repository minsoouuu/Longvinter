using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ObjectPoolSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotPrefabs;
    [SerializeField] private List<Item1> itemPrefabs;
    [SerializeField] private List<House> housePrefabs;
    [SerializeField] private List<Monster> monsterPrefabs;

    private Dictionary<ObjectType, Queue<GameObject>> objectPools = new Dictionary<ObjectType, Queue<GameObject>>();
    private Dictionary<ItemType, Queue<Item1>> itemPools = new Dictionary<ItemType, Queue<Item1>>();
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
            Enum.GetValues(typeof(ItemType)).Length,
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
                        objectPools[(ObjectType)(j)] = new Queue<GameObject>();
                        break;
                    case 1:
                        itemPools[(ItemType)(j)] = new Queue<Item1>();
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
    public void ReturnObject(ObjectType objectType, GameObject obj)
    {
        obj.SetActive(false);
        objectPools[objectType].Enqueue(obj);
    }
    public void ReturnObject(ItemType type, Item1 obj)
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
    public GameObject GetObjectOfObjectPooling(ObjectType objectType)
    {
        GameObject obj = null;

        if (objectPools[objectType].Count != 0)
        {
            obj = objectPools[objectType].Dequeue();
        }
        else
        {
            obj = Instantiate(slotPrefabs[0]);
        }
        obj.SetActive(true);
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
        }

        obj.gameObject.SetActive(true);
        return obj;
    }
    public Item1 GetObjectOfObjectPooling(ItemType type)
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
