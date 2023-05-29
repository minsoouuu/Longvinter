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
                if (equipments[i].data.itemName.ToString() == jsonData.equimentData.equipments[j].type.ToString())
                {
                    //[i].data.image = jsonData.equimentData.equipments[j].image;
                    equipments[i].data.price = jsonData.equimentData.equipments[j].price;
                    equipments[i].data.serial =jsonData.equimentData.equipments[j].serial;
                    equipments[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.equimentData.equipments[j].type);
                    equipments[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.equimentData.equipments[j].type);
                }
            }
        }
        for (int i = 0; i < materilas.Count; i++)
        {
            for (int j = 0; j < jsonData.materialData.materials.Count; j++)
            {
                if (materilas[i].data.itemName.ToString() == jsonData.materialData.materials[j].type.ToString())
                {
                    //materilas[i].data.image = jsonData.materialData.materials[j].image;
                    materilas[i].data.price = jsonData.materialData.materials[j].price;
                    materilas[i].data.serial = jsonData.materialData.materials[j].serial;
                    materilas[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.materialData.materials[j].type);
                    materilas[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.materialData.materials[j].type);
                }
            }
        }
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < jsonData.foodData.foods.Count; j++)
            {
                if (foods[i].data.itemName.ToString() == jsonData.foodData.foods[j].type.ToString())
                {
                    //foods[i].data.image = jsonData.foodData.foods[j].image;
                    foods[i].data.price = jsonData.foodData.foods[j].price;
                    foods[i].data.serial = jsonData.foodData.foods[j].serial;
                    foods[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.foodData.foods[j].type);
                    equipments[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.foodData.foods[j].type);
                }
            }
        }
        for (int i = 0; i < plants.Count; i++)
        {
            for (int j = 0; j < jsonData.plantData.plants.Count; j++)
            {
                if (plants[i].data.itemName.ToString() == jsonData.plantData.plants[j].type.ToString())
                {
                    //plants[i].data.image = jsonData.plantData.plants[j].image;
                    plants[i].data.price = jsonData.plantData.plants[j].price;
                    plants[i].data.serial = jsonData.plantData.plants[j].serial;
                    plants[i].data.itemType = EnumUtil<InvenItemType>.Parse(jsonData.plantData.plants[j].type);
                    plants[i].data.itemName = EnumUtil<ItemName>.Parse(jsonData.plantData.plants[j].type);
                }
            }
        }
    }

    // 스프라이트 가져오기.
    Sprite GetSpriteInAssets(string image)
    {
        return Resources.Load<Sprite>("");
    }
}
