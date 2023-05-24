using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MerchantController : MonoBehaviour
{
    [SerializeField] private Merchant b_itemlist;
    [SerializeField] private Transform b_parent;
    [SerializeField] private Merchant s_itemlist;
    [SerializeField] private Transform s_parent;
    [SerializeField] private List<Item> equipments_list = new List<Item>();
    List<List<Item>> Inventory_list = new List<List<Item>>();
    Inventory inven = new Inventory();

    

    // Start is called before the first frame update
    void Start()
    {
        inven = Gamemanager.instance.inventory;
        CreateMerchant_b_ItemList();
        CreateMerchant_s_ItemList();
    }

    // Update is called once per frame
    void Update()
    {
        Get_Inventory_Itemlist();
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
        for (int i = 0; i < Inventory_list.Count; i++)
        {
            Merchant gb = Instantiate(s_itemlist, s_parent);
            foreach (var item1 in Inventory_list)
            {
                foreach (var item in item1)
                {
                    gb.Setdata(item);
                }
            }
        }
    }

    void Get_Inventory_Itemlist()
    {
        List<List<Item>> temp = new List<List<Item>>();
        temp = inven.itemss.ToList();
        Inventory_list = temp;
    }
}
