using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataSetController : MonoBehaviour
{
    enum DataType
    {
        Item,
        Monster,
    }

    public List<Item> equipments;
    public List<Item> materilas;
    public List<Item> foods;
    public List<Item> plants;

    void SetData()
    {
        JsonData jsonData = Gamemanager.instance.jsonDataController;
        for (int i = 0; i < equipments.Count; i++)
        {
            for (int j = 0; j < jsonData.equimentData.equipments.Count; j++)
            {
                if (equipments[i].data.itemName.ToString() == jsonData.equimentData.equipments[j].name)
                {
                    equipments[i].data.price = jsonData.equimentData.equipments[j].price;
                    equipments[i].data.serial =jsonData.equimentData.equipments[j].serial;
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
                if (materilas[i].data.itemName.ToString() == jsonData.materialData.materials[j].name)
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
                if (foods[i].data.itemName.ToString() == jsonData.foodData.foods[j].name)
                {
                    foods[i].data.price = jsonData.foodData.foods[j].price;
                    foods[i].data.serial = jsonData.foodData.foods[j].serial;
                    foods[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.foodData.foods[j].type);
                    foods[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.foodData.foods[j].name);
                    foods[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.foodData.foods[j].type), jsonData.foodData.foods[j].image);
                }
            }
        }
        for (int i = 0; i < plants.Count; i++)
        {
            for (int j = 0; j < jsonData.plantData.plants.Count; j++)
            {
                if (plants[i].data.itemName.ToString() == jsonData.plantData.plants[j].name)
                {
                    plants[i].data.price = jsonData.plantData.plants[j].price;
                    plants[i].data.serial = jsonData.plantData.plants[j].serial;
                    plants[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.plantData.plants[j].type);
                    plants[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.plantData.plants[j].name);
                    plants[i].data.image = GetSpriteInAssets(EnumUtil<InvenItemType>.Parse(jsonData.plantData.plants[j].type), jsonData.plantData.plants[j].image);
                }
            }
        }
    }
    // 스프라이트 가져오기.
    Sprite GetSpriteInAssets(InvenItemType type, string name)
    {
        string path = "Longvinter_Icons";
        return Resources.Load<Sprite>(path + type.ToString() + name);
    }
}
