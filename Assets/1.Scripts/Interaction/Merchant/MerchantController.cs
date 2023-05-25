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
    [SerializeField] private Toggle[] tg;

    List<Item> merchant_blist = new List<Item>();
    List<Item> merchant_slist = new List<Item>();
    List<Item> Inventory_list = new List<Item>();
    Inventory inven = new Inventory();
    private void OnEnable()
    {
        
        CreateMerchant_b_ItemList();
    }
    // Start is called before the first frame update
    void Start()
    {
        inven = Gamemanager.instance.inventory;
    }

    // Update is called once per frame
    void Update()
    {
        Close_Merchant();
        Get_Inventory_Itemlist();
        CreateMerchant_s_ItemList();
    }

    void CreateMerchant_b_ItemList()
    {
        for (int i = 0; i < equipments_list.Count; i++)
        {
            if (merchant_blist.Contains(equipments_list[i]))
            {
                continue;
            }
            else
            {
                Merchant gb = Instantiate(b_itemlist, b_parent);
                equipments_list[i].Init();
                gb.Setdata(equipments_list[i]);
                merchant_blist.Add(gb.itemdata);
            }
        }
    }
    void CreateMerchant_s_ItemList()
    {
        for (int i = 0; i < inven.equipments.Count; i++)
        {
            if (merchant_slist.Contains(inven.equipments[i]))
            {
                continue;
            }
            else
            {
                
                Merchant gb = Instantiate(s_itemlist, s_parent);
                gb.Setdata(inven.equipments[i]);
                merchant_slist.Add(gb.itemdata);
            }
        }
    }

    void DeleteMerchant_s_ItemList()
    {
        List<Item> temp = new List<Item>();
        temp = inven.equipments.ToList();
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp.Contains(merchant_slist[i]))
            {
                return;
            }
            else
            {
                Item mc = s_parent.GetChild(i).GetComponent<Merchant>().itemdata;
            }
            
        }
    }

    Toggle SetToggle()
    {
        int index = 0;
        for(int i = 0; i < tg.Length; i++)
        {
            if (tg[i].isOn)
            {
                index = i;
                break;
            }
        }
        return tg[index];
    }

    public void OnClickToggle()
    {
        
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
