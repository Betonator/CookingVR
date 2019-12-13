using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string recipeName;
    public int[] ingredientIndexes;
    public float[] idealIngredientFriedLevels;
    public float[] ingredientProportions;
    public int idealDishSize;

    public Recipe(string recipeName, int[] ingredientIndexes,
        float[] idealIngredientFriedLevels, float[] ingredientProportions,
        int idealDishSize)
    {
        this.recipeName = recipeName;
        this.ingredientIndexes = ingredientIndexes;
        this.idealIngredientFriedLevels = idealIngredientFriedLevels;
        this.ingredientProportions = ingredientProportions;
        this.idealDishSize = idealDishSize;
    }
}
