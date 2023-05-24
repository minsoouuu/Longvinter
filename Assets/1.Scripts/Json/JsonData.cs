using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class JsonData : MonoBehaviour
{

    [SerializeField] private TextAsset recipeJson;
    [SerializeField] private TextAsset equimentJson;
    [SerializeField] private TextAsset materialJson;
    [SerializeField] private TextAsset foodJson;
    [SerializeField] private TextAsset plantJson;

    public Recipe recipeData = new Recipe();
    public Equiment equimentData = new Equiment();
    public Material materialData = new Material();
    public Food foodData = new Food();
    public Plant plantData = new Plant();

    [Serializable]
    public class RecipeJson
    {
        public string completeitem;
        public string material1;
        public string material2;
    }
    [Serializable]
    public class Recipe
    {
        public List<RecipeJson> recipe = new List<RecipeJson>();
    }
    [Serializable]
    public class EquimentJson
    {
        public string name;
        public string image;
        public string type;
        public int price;
        public int serial;
    }
    [Serializable]
    public class Equiment
    {
        public List<EquimentJson> equiments = new List<EquimentJson>();
    }
    [Serializable]
    public class FoodJson
    {
        public string name;
        public string image;
        public string type;
        public int price;
        public int serial;
    }
    [Serializable]
    public class Food
    {
        public List<FoodJson> foods = new List<FoodJson>();
    }
    [Serializable]
    public class MaterialJson
    {
        public string name;
        public string image;
        public string type;
        public int price;
        public int serial;
    }
    [Serializable]
    public class Material
    {
        public List<MaterialJson> materials = new List<MaterialJson>();
    }
    [Serializable]
    public class PlantJson
    {
        public string name;
        public string image;
        public string type;
        public int price;
        public int serial;
    }
    [Serializable]
    public class Plant
    {
        public List<PlantJson> plants = new List<PlantJson>();
    }

    private void Start()
    {
        recipeData = JsonUtility.FromJson<Recipe>(recipeJson.text);
        equimentData = JsonUtility.FromJson<Equiment>(equimentJson.text);
        foodData = JsonUtility.FromJson<Food>(foodJson.text);
        materialData = JsonUtility.FromJson<Material>(materialJson.text);
        plantData = JsonUtility.FromJson<Plant>(plantJson.text);
    }
}

