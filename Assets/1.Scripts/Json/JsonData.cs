using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class JsonData : MonoBehaviour
{

    [SerializeField] private TextAsset recipeJson;

    public Recipe recipeData = new Recipe();

    [Serializable]
    public class RecipeJson
    {
        string material1;
        string material2;
    }

    [Serializable]
    public class Recipe
    {
        public List<RecipeJson> fence = new List<RecipeJson>();
    }

    private void Start()
    {
        recipeData = JsonUtility.FromJson<Recipe>(recipeJson.text);
    }
}
