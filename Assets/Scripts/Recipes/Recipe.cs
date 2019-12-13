using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string recipeName;
    public List<int> ingredientIndexes;
    public List<float> idealIngredientFriedLevels;
    public List<float> ingredientProportions;
    public int idealDishSize;

    public Recipe(string recipeName, List<int> ingredientIndexes,
        List<float> idealIngredientFriedLevels, List<float> ingredientProportions,
        int idealDishSize)
    {
        this.recipeName = recipeName;
        this.ingredientIndexes = ingredientIndexes;
        this.idealIngredientFriedLevels = idealIngredientFriedLevels;
        this.ingredientProportions = ingredientProportions;
        this.idealDishSize = idealDishSize;
    }
}
