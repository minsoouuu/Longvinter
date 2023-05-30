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
    [HideInInspector] public Transform s_parent;
    [SerializeField] private Button close_btn;
    [SerializeField] private GameObject merchant;
    [SerializeField] private User player;
    [SerializeField] private Toggle[] tg;

    List<Item> equipments_list = new List<Item>();
    List<Item> merchant_blist = new List<Item>();
    List<Item> merchant_slist = new List<Item>();
    List<Item> Inventory_list = new List<Item>();
    Inventory inven;

    ObjectType myType = ObjectType.BuySlot;
    int num = 0;

    private void OnEnable()
    {
        CreateMerchant_b_ItemList();
    }
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("데이터 불러오기");
        inven = Gamemanager.instance.inventory;
        if (Gamemanager.instance.itemController.equipments.Count != 0)
        {
            for (int i = 0; i < Gamemanager.instance.itemController.equipments.Count; i++)
            {
                equipments_list.Add(Gamemanager.instance.itemController.equipments[i]);
            }
        }
        else
        {
            Debug.Log("데이터 없음");
        }
    }

    // Update is called once per frame
    void Update()
    {
        num = SetToggle();
        Close_Merchant();
        Get_Inventory_Itemlist();
        CreateMerchant_s_ItemList(0);
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
                Merchant slot = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(myType, true);
                slot.transform.SetParent(b_parent);
                slot.Setdata(equipments_list[i]);
                slot.mc = this;
                merchant_blist.Add(slot.itemdata);
            }
        }
    }
    public void CreateMerchant_s_ItemList(int num)
    {
        List<Item> list = new List<Item>();
        switch (num)
        {
            case 0:
                list = inven.equipments.ToList();
                break;
            case 1:
                list = inven.materials.ToList();
                break;
            case 2:
                list = inven.foods.ToList();
                break;
            case 3:
                list = inven.plants.ToList();
                break;
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (merchant_slist.Contains(list[i]))
            {
                continue;
            }
            else
            {
                Merchant slot = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(myType, false);
                slot.transform.SetParent(s_parent);
                slot.Setdata(inven.equipments[i]);
                slot.mc = this;
                merchant_slist.Add(slot.itemdata);
            }
        }
    }


    int SetToggle()
    {
        int index = 0;
        for (int i = 0; i < tg.Length; i++)
        {
            if (tg[i].isOn)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void OnClickToggle()
    {
        switch (num)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                CreateMerchant_s_ItemList(num);
                break;
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

    public void HideSlot(Merchant slot)
    {
        Gamemanager.instance.objectPool.ReturnObject(myType, slot);
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
