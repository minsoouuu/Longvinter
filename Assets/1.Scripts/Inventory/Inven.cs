using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    // �κ��丮 Ȱ��ȭ ����. true : ī�޶� ������ �� �ٸ� �Է� ����
    public static bool invectoryActivated = false;

    [SerializeField] private Item prefab;
    [SerializeField] private ItemData[] itemData;
    [SerializeField] private GameObject invenBG;
    [SerializeField] private Transform parent;

    public List<Item> invenlist = new List<Item>();

    [HideInInspector] public int InvenX { get; set; }
    [HideInInspector] public int InvenY { get; set; }



    void Start()
    {
        // �κ��丮â ���� 4��, ���η� 8�� �� 32��
        InvenX = 4;
        InvenY = 8;
        gameObject.SetActive(false);
        CreateInven();
    }

    void Update()
    {
        KeyOpenInventory();
    }

    // �κ��丮 �ڿ� Ÿ�� ����
    public void CreateInven()
    {
        for(int i = 0; i < InvenX * InvenY; i++)
        {
            Item gb =  Instantiate(prefab, parent);
            invenlist.Add(gb);
        }
    }

    private void KeyOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invectoryActivated = !invectoryActivated;

            if (invectoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        invenBG.SetActive(true);
    }

    private void CloseInventory()
    {
        invenBG.SetActive(false);
    }

    
}
