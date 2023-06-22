using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDataSetController : MonoBehaviour
{
    public List<Item> equipments;
    public List<Item> materilas;
    public List<Item> foods;
    public List<Item> plants;
    public Dictionary<ItemName, List<ItemName>> recipes = new Dictionary<ItemName, List<ItemName>>();
    private void Start()
    {
        SetData();
    }

    void SetData()
    {
        JsonData jsonData = Gamemanager.instance.jsonDataController;
        for (int i = 0; i < equipments.Count; i++)
        {
            for (int j = 0; j < jsonData.equimentData.equipments.Count; j++)
            {
                if (equipments[i].name == jsonData.equimentData.equipments[j].name)
                {
                    equipments[i].data.price = jsonData.equimentData.equipments[j].price;
                    equipments[i].data.serial = jsonData.equimentData.equipments[j].serial;
                    equipments[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.equimentData.equipments[j].type);
                    equipments[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.equimentData.equipments[j].name);
                    equipments[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.equimentData.equipments[j].type), jsonData.equimentData.equipments[j].image);
                }
            }
        }
        for (int i = 0; i < materilas.Count; i++)
        {
            for (int j = 0; j < jsonData.materialData.materials.Count; j++)
            {
                if (materilas[i].name == jsonData.materialData.materials[j].name)
                {
                    materilas[i].data.price = jsonData.materialData.materials[j].price;
                    materilas[i].data.serial = jsonData.materialData.materials[j].serial;
                    materilas[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.materialData.materials[j].type);
                    materilas[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.materialData.materials[j].name);
                    materilas[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.materialData.materials[j].type), jsonData.materialData.materials[j].image);

                }
            }
        }
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < jsonData.foodData.foods.Count; j++)
            {
                if (foods[i].name == jsonData.foodData.foods[j].name)
                {
                    foods[i].data.price = jsonData.foodData.foods[j].price;
                    foods[i].data.serial = jsonData.foodData.foods[j].serial;
                    foods[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.foodData.foods[j].type);
                    foods[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.foodData.foods[j].name);
                    foods[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.foodData.foods[j].type), jsonData.foodData.foods[j].image);
                    foods[i].data.stats = jsonData.foodData.foods[j].stats;
                }
            }
        }
        for (int i = 0; i < plants.Count; i++)
        {
            for (int j = 0; j < jsonData.plantData.plants.Count; j++)
            {
                if (plants[i].name == jsonData.plantData.plants[j].name)
                {
                    plants[i].data.price = jsonData.plantData.plants[j].price;
                    plants[i].data.serial = jsonData.plantData.plants[j].serial;
                    plants[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.plantData.plants[j].type);
                    plants[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.plantData.plants[j].name);
                    plants[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.plantData.plants[j].type), jsonData.plantData.plants[j].image);
                }
            }
        }
        for (int i = 0; i < Gamemanager.instance.jsonDataController.recipeData.recipe.Count; i++)
        {
            recipes[Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].completeitem)] = new List<ItemName>();

            recipes[Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].completeitem)].
                Add(Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].material1));

            recipes[Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].completeitem)].
                Add(Enum.Parse<ItemName>(Gamemanager.instance.jsonDataController.recipeData.recipe[i].material2));
        }
    }
    // ��������Ʈ ��������.
    Sprite GetSpriteInAssets(InvenItemType type, string name)
    {
        string path = $"Longvinter_Icons/{type}/{name}";
        return Resources.Load<Sprite>(path);
    }
    public Item GetItem(ItemName name)
    {
        Item item = null;
        List<List<Item>> items = new List<List<Item>>();
        items.Add(equipments);
        items.Add(materilas);
        items.Add(foods);
        items.Add(plants);

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].Count; j++)
            {
                if (items[i][j].data.itemName == name)
                {
                    item = items[i][j];
                    break;
                }
            }
        }
        return item;
    }
    public Item GetItem(ItemName name, InvenItemType type)
    {
        Item item = null;
        switch (type)
        {
            case InvenItemType.Equipments:
                for (int i = 0; i < equipments.Count; i++)
                {
                    if (equipments[i].data.itemName == name)
                    {
                        item = equipments[i];
                        break;
                    }
                }
                break;
            case InvenItemType.Materials:
                for (int i = 0; i < materilas.Count; i++)
                {
                    if (materilas[i].data.itemName == name)
                    {
                        item = materilas[i];
                        break;
                    }
                }
                break;
            case InvenItemType.Foods:
                for (int i = 0; i < foods.Count; i++)
                {
                    if (foods[i].data.itemName == name)
                    {
                        item = foods[i];
                        break;
                    }
                }
                break;
            case InvenItemType.Plants:
                for (int i = 0; i < plants.Count; i++)
                {
                    if (plants[i].data.itemName == name)
                    {
                        item = plants[i];
                        break;
                    }
                }
                break;
        }
        return item;
    }
}