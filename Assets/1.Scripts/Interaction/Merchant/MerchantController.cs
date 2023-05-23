using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantController : MonoBehaviour
{
    [SerializeField] private Merchant b_itemlist;
    [SerializeField] private Transform b_parent;
    [SerializeField] private Merchant s_itemlist;
    [SerializeField] private Transform s_parent;
    [SerializeField] private List<Item> equipments_list = new List<Item>();

    

    // Start is called before the first frame update
    void Start()
    {
        CreateMerchant_b_ItemList();
        CreateMerchant_s_ItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMerchant_b_ItemList()
    {
        for (int i = 0; i < equipments_list.Count; i++)
        {
            Merchant gb = Instantiate(b_itemlist, b_parent);
            equipments_list[i].Init();
            gb.Setdata(equipments_list[i]);
        }
    }
    void CreateMerchant_s_ItemList()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(s_itemlist, s_parent);
        }
    }
}
