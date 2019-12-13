using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabaseController : MonoBehaviour
{
    private List<Recipe> recipeList;
    public Recipe currentRecipe;
    [SerializeField]
    private RecipeCheckArea checkArea;

    void Awake()
    {
        BuildRecipeList();
        SetCurrentRecipe(0); //later to be removed
    }

    void BuildRecipeList()
    {
        recipeList = new List<Recipe>()
        {
            new Recipe("BaconTomato", //name
            new int[]{ 1, 2 }, //ingredient indexes
            new float[]{ 80f, 90f}, //ingredient ideal fried levels
            new float[]{ 0.4f, 0.6f}, //ingredient proportions (make sure the sum is 1)
            20), //ideal dish size
            new Recipe("BaconMushroom",
            new int[]{ 1, 3 },
            new float[]{ 60f, 80f},
            new float[]{ 0.5f, 0.5f},
            30),
            new Recipe("TomatoMushroom",
            new int[]{ 2, 3 },
            new float[]{ 50f, 70f},
            new float[]{ 0.3f, 0.7f},
            25)
        };
    }

    public void SetCurrentRecipe(int recipeIndex)
    {
        currentRecipe = recipeList[recipeIndex];
    }

    public float CheckDish()
    {
        float grade = 1.0f;

        foreach(Ingredient ingredient in checkArea.ingredients)
        {

        }

        Debug.Log("Your result: " + grade + "/5.0! Good job!");
        return grade;
    }
}

/*
    Ingredient indexes:
    1 - Bacon
    2 - Tomato
    3 - Mushroom
*/
