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
public struct Data_Json
{
    public string name;
    public string image;
    public string type;
    public int price;
    public int serial;
}

public abstract class Item1 : MonoBehaviour
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

    public abstract void Action();
}
