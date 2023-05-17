using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    // �κ��丮 Ȱ��ȭ ����. true : ī�޶� ������ �� �ٸ� �Է� ����
    public static bool invectoryActivated = false;

    [SerializeField]
    private GameObject invenBG;
    [SerializeField] private GameObject inven_Slot;
    [SerializeField] private Transform parent;

    [HideInInspector] public int InvenX { get; set; }
    [HideInInspector] public int InvenY { get; set; }

   public  List<GameObject> invenlist = new List<GameObject>();


    void Start()
    {
        // �κ��丮â ���� 4��, ���η� 8�� �� 32��
        InvenX = 4;
        InvenY = 8;

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
            GameObject gb =  Instantiate(inven_Slot, parent);
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
