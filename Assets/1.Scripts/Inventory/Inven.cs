using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    [SerializeField] private GameObject inven_tile;
    [SerializeField] private Transform parent;

    [HideInInspector] public int InvenX { get; set; }
    [HideInInspector] public int InvenY { get; set; }

    List<GameObject> invenlist = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // 인벤토리창 가로 4개, 세로로 8줄 총 32개
        InvenX = 4;
        InvenY = 8;

        CreateInven();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 인벤토리 뒤에 타일 생성
    public void CreateInven()
    {
        for(int i = 0; i < InvenX * InvenY; i++)
        {
            GameObject gb =  Instantiate(inven_tile, parent);
            invenlist.Add(gb);
        }
    }
    
    public void AddItem()
    {

    }
}
