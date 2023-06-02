using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class MakingController : MonoBehaviour
{
    [SerializeField] private MaterialSlot[] MaterialSlot;
    [SerializeField] private Button button;

    [HideInInspector] public List<ItemName> items = new List<ItemName>();
    List<JsonData.RecipeJson> recipes = new List<JsonData.RecipeJson>();

    public CompleteSlot completeSlot;
    public bool Ison { get; set; }
    private void Start()
    {
        recipes = Gamemanager.instance.jsonDataController.recipeData.recipe.ToList();
        button.onClick.AddListener(() => OnButtonDownComplete());
        Debug.Log(items.Count);
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
    }
    public void SetSlotData(Item item)
    {
        for (int i = 0; i < MaterialSlot.Length; i++)
        {
            if (MaterialSlot[i].ItemData == null)
            {
                MaterialSlot[i].ItemData = item;
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
        //Gamemanager.instance.player.inven.AddItem(completeSlot.ItemData);
        for (int i = 0; i < MaterialSlot.Length; i++)
        {
            if (MaterialSlot[i].ItemData != null)
            {
                // 인벤에서 재료 차감
                //Gamemanager.instance.player.inven.DeleteItem(MaterialSlot[i].ItemData);
            }
        }
        SlotDataReset();
    }
    void SlotDataReset()
    {
        items.Clear();
        for (int i = 0; i < MaterialSlot.Length; i++)
        {
            MaterialSlot[i].ItemData = null;
        }
        completeSlot.ItemData = null;
    }

    // Test .... 
    void Test()
    {
        if (items.Count < 2)
            return;
        List<JsonData.RecipeJson> curRecipe = new List<JsonData.RecipeJson>();
        ItemName comName = new ItemName();
        InvenItemType type = new InvenItemType();
        for (int i = 0; i < MaterialSlot.Length; i++)
        {
            if (MaterialSlot[i].ItemData == null)
                return;
            for (int j = 0; j < recipes.Count; j++)
            {
                if (i == 0)
                {
                    if (MaterialSlot[i].ItemData.data.itemName.ToString() == recipes[j].material1)
                    {
                        curRecipe.Add(recipes[j]);
                    }
                }
                if (i == 1)
                {
                    if (MaterialSlot[i].ItemData.data.itemName.ToString() == curRecipe[j].material2)
                    {
                        comName = Enum.Parse<ItemName>(curRecipe[j].completeitem);
                        type = Enum.Parse<InvenItemType>(curRecipe[j].type);
                    }
                }
            }
        }
        completeSlot.ItemData = Gamemanager.instance.itemController.GetItem(comName, type);
        Debug.Log(Gamemanager.instance.itemController.GetItem(comName, type).name);
    }
}
