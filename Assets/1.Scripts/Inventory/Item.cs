using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InvenItemType
{
    Equipments,      
    Materials,      
    Foods,
    Plants
}
public struct Data
{
    public string itemName;
    public InvenItemType itemType;
    public Sprite itemImage; // ???????? ?????? ???? ?????? ??????
    public int mk;
    public int serialNum;
}

public abstract class Item : MonoBehaviour
{
    public int Count
    {
        get;set;
    }
    private void Awake()
    {
        Init();
    }
    public Data data = new Data();
    private void Start()
    {
        Count = 0;
    }

    public abstract void Init();
    public abstract void Action();
    

}


