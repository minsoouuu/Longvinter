using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
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

