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
}

public abstract class Item : MonoBehaviour
{
    public Data data = new Data();
    private void Start()
    {
        Init();
    }

    public abstract void Init();
    public abstract void Action();


}


