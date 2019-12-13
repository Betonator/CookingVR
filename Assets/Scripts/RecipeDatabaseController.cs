using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabaseController : MonoBehaviour
{
    private List<Recipe> recipeList;
    public Recipe currentRecipe;

    void Awake()
    {
        BuildRecipeList();
        SetCurrentRecipe(0); //later to be removed
    }

    void BuildRecipeList()
    {
        recipeList = new List<Recipe>()
        {
            new Recipe("BaconTomato", 
            new int[]{ 1, 2 }, 
            new float[]{ 80f, 90f}),
            new Recipe("BaconMushroom",
            new int[]{ 1, 3 },
            new float[]{ 60f, 80f}),
            new Recipe("TomatoMushroom",
            new int[]{ 2, 3 },
            new float[]{ 50f, 70f})
        };
    }

    public void SetCurrentRecipe(int recipeIndex)
    {
        currentRecipe = recipeList[recipeIndex];
    }
}

/*
    Ingredient indexes:
    1 - Bacon
    2 - Tomato
    3 - Mushroom
*/
