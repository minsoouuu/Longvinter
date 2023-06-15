using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MerchantController : MonoBehaviour
{
    public enum MerchantKind
    {
        Equipment,
        Material,
        Food,
        Plant
    }
    [SerializeField] private Merchant b_itemlist;
    [SerializeField] private Transform b_parent;
    [SerializeField] private Merchant s_itemlist;
    [HideInInspector] public Transform s_parent;
    [SerializeField] private Button close_btn;
    [SerializeField] private GameObject merchant;
    [SerializeField] private User player;
    [SerializeField] private Toggle[] tg;
    [SerializeField] private MerchantKind mKind;

    List<Item> item_list = new List<Item>();
    List<Item> merchant_blist = new List<Item>();
    [HideInInspector] public List<Item> merchant_slist = new List<Item>();
    List<Item> Inventory_list = new List<Item>();

    [HideInInspector] public List<Merchant> slot_list = new List<Merchant>(); 
    [HideInInspector] public ObjectType myTypeB = ObjectType.BuySlot;
    [HideInInspector] public ObjectType myTypeS = ObjectType.SellSlot;
    [HideInInspector] public int num = 0;

    private void OnEnable()
    {
        CreateMerchant_b_ItemList();
        
    }

    // 상인목록 설정
    // Start is called before the first frame update
    void Awake()
    {
        switch (mKind)
        {
            case MerchantKind.Equipment:
                if (Gamemanager.instance.itemController.equipments.Count != 0)
                {
                    for (int i = 0; i < Gamemanager.instance.itemController.equipments.Count; i++)
                    {
                        item_list.Add(Gamemanager.instance.itemController.equipments[i]);
                    }
                }
                break;
            case MerchantKind.Material:
                if (Gamemanager.instance.itemController.materilas.Count != 0)
                {
                    for (int i = 0; i < Gamemanager.instance.itemController.materilas.Count; i++)
                    {
                        item_list.Add(Gamemanager.instance.itemController.materilas[i]);
                    }
                }
                break;
            case MerchantKind.Food:
                if (Gamemanager.instance.itemController.foods.Count != 0)
                {
                    for (int i = 0; i < Gamemanager.instance.itemController.foods.Count; i++)
                    {
                        item_list.Add(Gamemanager.instance.itemController.foods[i]);
                    }
                }
                break;
            case MerchantKind.Plant:
                if (Gamemanager.instance.itemController.plants.Count != 0)
                {
                    for (int i = 0; i < Gamemanager.instance.itemController.plants.Count; i++)
                    {
                        item_list.Add(Gamemanager.instance.itemController.plants[i]);
                    }
                }
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Close_Merchant();
        CreateMerchant_s_ItemList(Gamemanager.instance.player.im.curToggle);
    }

    // 상인 판매 목록 생성
    void CreateMerchant_b_ItemList()
    {
        for (int i = 0; i < item_list.Count; i++)
        {
            // 중복 검사
            if (merchant_blist.Contains(item_list[i]))
            {
                continue;
            }
            else
            {
                Merchant slot = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(myTypeB, true);
                slot.transform.SetParent(b_parent);
                slot.Setdata(item_list[i]);
                slot.mc = this;
                merchant_blist.Add(slot.itemdata);
            }
        }
    }

    // 인벤토리에 있는 아이템 판매 목록 생성
    public void CreateMerchant_s_ItemList(Toggle toggle)
    {
        List<Item> list = new List<Item>();
        toggle = Gamemanager.instance.player.im.curToggle;
        if(toggle == Gamemanager.instance.player.im.toggles[0])
        {
            list = Gamemanager.instance.player.im.itemDic[InventoryManager.TitleType.Equipment].ToList();
        }
        else if(toggle == Gamemanager.instance.player.im.toggles[1])
        {
            list = Gamemanager.instance.player.im.itemDic[InventoryManager.TitleType.Material].ToList();
        }
        else if (toggle == Gamemanager.instance.player.im.toggles[2])
        {

            list = Gamemanager.instance.player.im.itemDic[InventoryManager.TitleType.Food].ToList();
        }
        else
        {
            list = Gamemanager.instance.player.im.itemDic[InventoryManager.TitleType.Plant].ToList();
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (merchant_slist.Contains(list[i]))
            {
                continue;
            }
            else
            {
                Merchant slot = Gamemanager.instance.objectPool.GetObjectOfObjectPooling(myTypeS, false);
                slot.transform.SetParent(s_parent);
                slot.Setdata(list[i]);
                slot.mc = this;
                merchant_slist.Add(slot.itemdata);
                slot_list.Add(slot);

            }
        }
    }

    public void SlotOFF()
    {
        for(int i = 0; i < slot_list.Count; i++)
        {
            Gamemanager.instance.objectPool.ReturnObject(myTypeS, slot_list[i]);
        }
    }

    public void HideSlot(Merchant slot)
    {
        Gamemanager.instance.objectPool.ReturnObject(myTypeS, slot);
    }

    // 상인 닫기 버튼 이벤트
    public void onClick_CloseBtn()
    {
        merchant.SetActive(false);
        player.GetComponent<User>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
    }

    // 상인 닫기 이벤트 (esc 활용)
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
