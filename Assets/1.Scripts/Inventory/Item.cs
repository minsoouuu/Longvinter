using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InvenItemType
{
    Backpack,       // 배낭
    Equipment,      // 장비
    Collection      // 도감
}
public struct Data
{
    public string itemName;
    public InvenItemType itemType;
    public Sprite itemImage; // 인벤토리 안에서 띄울 아이템 이미지
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


