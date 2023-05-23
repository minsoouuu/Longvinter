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
    int count = 0;
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    public Data data = new Data();
    private void Start()
    {

    }

    public abstract void Init();
    public abstract void Action();
    

}


