using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InvenItemType
{
    Backpack,       // �賶
    Equipment,      // ���
    Collection      // ����
}
public struct Data
{
    public string itemName;
    public InvenItemType itemType;
    public Sprite itemImage; // �κ��丮 �ȿ��� ��� ������ �̹���
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


