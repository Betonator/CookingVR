using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string recipeName;
    public int[] ingredientIndexes;
    public float[] idealIngredientFriedLevels;

    public Recipe(string recipeName, int[] ingredientIndexes,
        float[] idealIngredientFriedLevels)
    {
        this.recipeName = recipeName;
        this.ingredientIndexes = ingredientIndexes;
        this.idealIngredientFriedLevels = idealIngredientFriedLevels;
    }
}
