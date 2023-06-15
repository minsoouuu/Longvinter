using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class MakingController : MonoBehaviour
{
    [SerializeField] private MaterialSlot[] materialSlot;
    [SerializeField] private Button button;
    [SerializeField] private GameObject interUI;

    [HideInInspector] public List<ItemName> items = new List<ItemName>();
    List<JsonData.RecipeJson> recipes = new List<JsonData.RecipeJson>();

    public CompleteSlot completeSlot;
    public bool IsOn { get; set; }

    private void Start()
    {
        recipes = Gamemanager.instance.jsonDataController.recipeData.recipe.ToList();
        button.onClick.AddListener(() => OnButtonDownComplete());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetSlotData(Gamemanager.instance.itemController.GetItem(ItemName.SugarBeet, InvenItemType.Materials));
            Debug.Log("설탕 추가");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetSlotData(Gamemanager.instance.itemController.GetItem(ItemName.Bread, InvenItemType.Foods));
            Debug.Log("빵 추가");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsOn == true)
            {
                IsOn = false;
                for (int i = 0; i < materialSlot.Length; i++)
                {
                    if (materialSlot[i].ItemData != null)
                    {
                        Item item = Gamemanager.instance.itemController.GetItem(materialSlot[i].ItemData.data.itemName);
                        Gamemanager.instance.player.im.ADItem(item, true);
                    }
                }
                SlotDataReset();
                transform.GetChild(0).gameObject.SetActive(false);
                Gamemanager.instance.player.im.mc = null;
            }
        }
    }
    public void SetSlotData(Item item)
    {
        if (items.Count >= 3)
            return;

        Item newitem = Gamemanager.instance.itemController.GetItem(item.data.itemName);
        for (int i = 0; i < materialSlot.Length; i++)
        {
            if (materialSlot[i].ItemData == null)
            {
                materialSlot[i].ItemData = newitem;
                items.Add(newitem.data.itemName);
                Gamemanager.instance.player.im.ADItem(newitem, false);
                break;
            }
        }

        if (items.Count >= 2)
        {
            Debug.Log("완성품");
            CheckSlot();
        }
    }
    void CheckSlot()
    {
        ItemDataSetController dataSetCont = Gamemanager.instance.itemController;

        int count = 0;
        foreach (var key in dataSetCont.recipes.Keys)
        {
            //Debug.Log($"{key} : {dataSetCont.recipes[key][0]} , {dataSetCont.recipes[key][1]}");
            
            if (items.Contains(dataSetCont.recipes[key][count]))
            {
                count++;
                if (items.Contains(dataSetCont.recipes[key][count]))
                {
                    completeSlot.ItemData = Gamemanager.instance.itemController.GetItem(key);
                    Debug.Log(Gamemanager.instance.itemController.GetItem(key).name);
                    break;
                }
                else
                {
                    SlotDataReset();
                }
            }
        }
    }
    void OnButtonDownComplete()
    {
        Debug.Log("완성");
        if (completeSlot.ItemData == null)
            return;
        // 인벤에 재료 추가
        Gamemanager.instance.player.im.ADItem(completeSlot.ItemData,true);

        // 인벤에서 재료 차감
        for (int i = 0; i < materialSlot.Length; i++)
        {
            if (materialSlot[i].ItemData != null)
            {
                //Gamemanager.instance.player.im.ADItem(materialSlot[i].ItemData, false);
            }
        }
        SlotDataReset();
    }
    // 제작대 재료 전부 초기화
    void SlotDataReset()
    {
        items.Clear();
        for (int i = 0; i < materialSlot.Length; i++)
        {
            materialSlot[i].ItemData = null;
        }
        completeSlot.ItemData = null;
    }
}
