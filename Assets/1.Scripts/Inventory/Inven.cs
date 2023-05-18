using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    // 인벤토리 활성화 여부. true : 카메라 움직임 및 다른 입력 막기
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
        // 인벤토리창 가로 4개, 세로로 8줄 총 32개
        InvenX = 4;
        InvenY = 8;
        gameObject.SetActive(false);
        CreateInven();
    }

    void Update()
    {
        KeyOpenInventory();
    }

    // 인벤토리 뒤에 타일 생성
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
