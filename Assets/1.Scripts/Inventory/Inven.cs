using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    // �κ��丮 Ȱ��ȭ ����. true : ī�޶� ������ �� �ٸ� �Է� ����
    public static bool invectoryActivated = false;

    [SerializeField] private Slot prefab;
    [SerializeField] private Item[] itemData;
    [SerializeField] private GameObject invenBG;
    [SerializeField] private Transform parent;

    public List<Slot> invenlist = new List<Slot>();

    [HideInInspector] public int InvenX { get; set; }
    [HideInInspector] public int InvenY { get; set; }



    void Start()
    {
        // �κ��丮â ���� 4��, ���η� 5�� �� 20��
        InvenX = 4;
        InvenY = 5;
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
            Slot gb =  Instantiate(prefab, parent);
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
