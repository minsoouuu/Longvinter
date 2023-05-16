using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum InvenItemType
    {
        Backpack,       // 배낭
        Equipment,      // 장비
        Collection      // 도감
    }


    public string itemName;
    public InvenItemType itemType;
    public Sprite itemImage; // 인벤토리 안에서 띄울 아이템 이미지
    public GameObject itemPrefab;  // 아이템 프리팹

}

