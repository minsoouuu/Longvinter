using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance = null;

    public User player;
    public InventoryManager inventory;
    public JsonData jsonDataController;
    public ObjectPoolSystem objectPool;
    public ItemDataSetController itemController;
    public Transform parentDropItem;
    public MakingController makingController;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
