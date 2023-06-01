using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class MakingController : MonoBehaviour
{
    [SerializeField] private MakingSlot[] makingSlots;
    [SerializeField] private MakingSlot comPleteSlot;
    [SerializeField] private Button button;

    [HideInInspector] public List<Item> items = new List<Item>();

    List<JsonData.RecipeJson> recipes = new List<JsonData.RecipeJson>();

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
            Debug.Log("¼³ÅÁ Ãß°¡");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetSlotData(Gamemanager.instance.itemController.GetItem(ItemName.Bread, InvenItemType.Foods));
            Debug.Log("»§ Ãß°¡");
        }
    }
    public void SetSlotData(Item item)
    {
        for (int i = 0; i < makingSlots.Length; i++)
        {
            if (makingSlots[i].ItemData == null)
            {
                makingSlots[i].ItemData = item;
            }
        }
        if (items.Count >= 2)
        {
            Debug.Log("¿Ï¼ºÇ°");
            CheckSlot();
        }
    }
    void CheckSlot()
    {

        ItemDataSetController dataSetCont = Gamemanager.instance.itemController;

        foreach (var key in dataSetCont.recipes.Keys)
        {
            //Debug.Log($"{key} : {dataSetCont.recipes[key][0]} , {dataSetCont.recipes[key][1]}");
            if (dataSetCont.recipes[key].Contains(makingSlots[0].ItemData.data.itemName) && dataSetCont.recipes[key].Contains(makingSlots[1].ItemData.data.itemName))
            {
                comPleteSlot.ItemData = Gamemanager.instance.itemController.GetItem(key);
                Debug.Log(Gamemanager.instance.itemController.GetItem(key).name);
                Debug.Log(comPleteSlot.ItemData.data.itemName);
                break;
            }
        }
    }
    void OnButtonDownComplete()
    {
        if (comPleteSlot.ItemData == null)
            return;
        Gamemanager.instance.player.inven.AddItem(comPleteSlot.ItemData);
        for (int i = 0; i < makingSlots.Length; i++)
        {
            if (makingSlots[i].ItemData != null)
            {
                Gamemanager.instance.player.inven.DeleteItem(makingSlots[i].ItemData);
                makingSlots[i].ItemData = null;
            }
        }
        Gamemanager.instance.player.inven.DeleteItem(comPleteSlot.ItemData);
        comPleteSlot.ItemData = null;
        SlotDataReset();
    }
    void SlotDataReset()
    {
        for (int i = 0; i < makingSlots.Length; i++)
        {
            makingSlots[i].ItemData = null;
        }
        comPleteSlot.ItemData = null;
    }


    // Test .... 
    void Test()
    {
        if (items.Count < 2)
            return;
        List<JsonData.RecipeJson> curRecipe = new List<JsonData.RecipeJson>();
        ItemName comName = new ItemName();
        InvenItemType type = new InvenItemType();
        for (int i = 0; i < makingSlots.Length; i++)
        {
            if (makingSlots[i].ItemData == null)
                return;
            for (int j = 0; j < recipes.Count; j++)
            {
                if (i == 0)
                {
                    if (makingSlots[i].ItemData.data.itemName.ToString() == recipes[j].material1)
                    {
                        curRecipe.Add(recipes[j]);
                    }
                }
                if (i == 1)
                {
                    if (makingSlots[i].ItemData.data.itemName.ToString() == curRecipe[j].material2)
                    {
                        comName = Enum.Parse<ItemName>(curRecipe[j].completeitem);
                        type = Enum.Parse<InvenItemType>(curRecipe[j].type);
                    }
                }
            }
        }
        comPleteSlot.ItemData = Gamemanager.instance.itemController.GetItem(comName, type);
        Debug.Log(Gamemanager.instance.itemController.GetItem(comName, type).name);
    }
    
   
}
