using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance = null;

    public GameObject player;
    public Inventory inventory;
    public JsonData jsonDataController;
    public ObjectPoolSystem objectPool;

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
