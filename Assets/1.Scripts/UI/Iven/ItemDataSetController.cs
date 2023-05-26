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

    public List<Item1> equipments;
    public List<Item1> materilas;
    public List<Item1> foods;
    public List<Item1> plants;

    void Start()
    {
        
    }
    void SetData()
    {
        JsonData jsonData = Gamemanager.instance.jsonDataController;
        for (int i = 0; i < equipments.Count; i++)
        {
            for (int j = 0; j < jsonData.equimentData.equipments.Count; j++)
            {
                if (equipments[i].itemType.ToString() == jsonData.equimentData.equipments[j].type.ToString())
                {
                    equipments[i].data.image = jsonData.equimentData.equipments[j].image;
                    equipments[i].data.price = jsonData.equimentData.equipments[j].price;
                    equipments[i].data.serial =jsonData.equimentData.equipments[j].serial;
                    equipments[i].data.type = jsonData.equimentData.equipments[j].type.ToString();
                }
            }
        }
        for (int i = 0; i < materilas.Count; i++)
        {
            for (int j = 0; j < jsonData.materialData.materials.Count; j++)
            {
                if (materilas[i].itemType.ToString() == jsonData.equimentData.equipments[j].type.ToString())
                {
                    materilas[i].data.image = jsonData.materialData.materials[j].image;
                    materilas[i].data.price = jsonData.materialData.materials[j].price;
                    materilas[i].data.serial = jsonData.materialData.materials[j].serial;
                    materilas[i].data.type = jsonData.materialData.materials[j].type;
                }
            }
        }
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < jsonData.foodData.foods.Count; j++)
            {
                if (foods[i].itemType.ToString() == jsonData.equimentData.equipments[j].type.ToString())
                {
                    foods[i].data.image = jsonData.foodData.foods[j].image;
                    foods[i].data.price = jsonData.foodData.foods[j].price;
                    foods[i].data.serial = jsonData.foodData.foods[j].serial;
                    foods[i].data.type = jsonData.foodData.foods[j].type.ToString();
                }
            }
        }
        for (int i = 0; i < plants.Count; i++)
        {
            for (int j = 0; j < jsonData.plantData.plants.Count; j++)
            {
                if (plants[i].itemType.ToString() == jsonData.equimentData.equipments[j].type.ToString())
                {
                    plants[i].data.image = jsonData.plantData.plants[j].image;
                    plants[i].data.price = jsonData.plantData.plants[j].price;
                    plants[i].data.serial = jsonData.plantData.plants[j].serial;
                    plants[i].data.type = jsonData.plantData.plants[j].type;
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
