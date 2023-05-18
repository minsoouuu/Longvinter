using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/item")]
public class ItemData : ScriptableObject
{
    public enum InvenItemType
    {
        Backpack,       // �賶
        Equipment,      // ���
        Collection      // ����
    }


    public string itemName;
    public InvenItemType itemType;
    public Sprite itemImage; // �κ��丮 �ȿ��� ��� ������ �̹���
    public GameObject itemPrefab;  // ������ ������

}

