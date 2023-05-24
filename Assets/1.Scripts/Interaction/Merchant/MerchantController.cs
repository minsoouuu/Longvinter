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
    [SerializeField] private Button close_btn;
    [SerializeField] private GameObject merchant;
    [SerializeField] private User player;

    List<Item> merchant_list = new List<Item>();
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
        Close_Merchant();
    }

    void CreateMerchant_b_ItemList()
    {
        for (int i = 0; i < equipments_list.Count; i++)
        {
            if (merchant_list.Contains(equipments_list[i]))
            {
                return;
            }
            Merchant gb = Instantiate(b_itemlist, b_parent);
            equipments_list[i].Init();
            gb.Setdata(equipments_list[i]);
            merchant_list.Add(gb.itemdata);
        }
    }
    void CreateMerchant_s_ItemList()
    {
        foreach (var item in Inventory_list)
        {
            Merchant gb = Instantiate(s_itemlist, s_parent);
            gb.Setdata(item);
        }
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

    public void onClick_CloseBtn()
    {
        merchant.SetActive(false);
        player.GetComponent<User>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
    }

    public void Close_Merchant()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            merchant.SetActive(false);
            player.GetComponent<User>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
        }
    }
}
