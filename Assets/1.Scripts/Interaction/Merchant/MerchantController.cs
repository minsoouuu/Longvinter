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
    List<Item> Inventory_list = new List<Item>();
    Inventory inven = new Inventory();


    private void OnEnable()
    {
        Get_Inventory_Itemlist();
        CreateMerchant_b_ItemList();
        CreateMerchant_s_ItemList();
    }
    // Start is called before the first frame update
    void Awake()
    {
        inven = Gamemanager.instance.inventory;
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
        for (int i = 0; i < Inventory_list.Count; i++)
        {
            Merchant gb = Instantiate(s_itemlist, s_parent);
            foreach (var item in Inventory_list)
            {
                gb.Setdata(item);
            }
        }
        Debug.Log(Inventory_list.Count);
    }

    void Get_Inventory_Itemlist()
    {
        foreach (var item in inven.equipments)
        {
            Inventory_list.Add(item);
        }
        foreach (var item in inven.foods)
        {
            Inventory_list.Add(item);
        }
        foreach (var item in inven.materials)
        {
            Inventory_list.Add(item);
        }
        foreach (var item in inven.plants)
        {
            Inventory_list.Add(item);
        }
    }
}
