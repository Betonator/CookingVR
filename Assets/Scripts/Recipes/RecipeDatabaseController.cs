using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabaseController : MonoBehaviour
{
    private List<Recipe> recipeList;
    public Recipe currentRecipe;
    [SerializeField]
    private RecipeCheckArea checkArea;

    private List<float> ingredientProportions = new List<float>();
    private List<float> ingredientFriedLevels = new List<float>();
    private int dishSize;

    void Awake()
    {
        BuildRecipeList();
    }

    private void Start()
    {
        SetCurrentRecipe(2); //later to be removed
    }

    private void Update() //later to be removed
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckDish();
        }
    }

    void BuildRecipeList()
    {
        recipeList = new List<Recipe>()
        {
            new Recipe("BaconTomato", //name
            new List<int>{ 0, 1 }, //ingredient indexes
            new List<float>{ 80f, 90f}, //ingredient ideal fried levels
            new List<float>{ 0.4f, 0.6f}, //ingredient proportions (make sure the sum is 1)
            20), //ideal dish size
            new Recipe("BaconMushroom",
            new List<int>{ 0, 2 },
            new List<float>{ 60f, 80f},
            new List<float>{ 0.5f, 0.5f},
            30),
            new Recipe("TomatoMushroom",
            new List<int>{ 1, 2 },
            new List<float>{ 50f, 70f},
            new List<float>{ 0.3f, 0.7f},
            25)
        };
    }

    public void SetCurrentRecipe(int recipeIndex)
    {
        currentRecipe = recipeList[recipeIndex];
    }

    public void SetCurrentRecipe(string recipeName)
    {
        currentRecipe = recipeList.Find(recipe => recipe.recipeName == recipeName);
    }

    public float CheckDish()
    {
        dishSize = checkArea.ingredients.Count;

        float ingredientFryLevelGrade = 0f;
        float ingredientProportionGrade = 0f;
        float dishSizeGrade = 0f;
        float ingredientFriedLevelSum;
        float ingredientAmounts;

        for (int i = 0; i < currentRecipe.ingredientIndexes.Count; i++)
        {
            ingredientProportions.Add(0.0f);
            ingredientFriedLevels.Add(0.0f);
            ingredientFriedLevelSum = 0f;
            ingredientAmounts = 0;
            foreach (Ingredient ingredient in checkArea.ingredients)
            {
                if (ingredient.ingredientNameIndex == currentRecipe.ingredientIndexes[i])
                {
                    ingredientAmounts += 1;
                    ingredientFriedLevelSum += ingredient.currentFriedLevel;
                }
            }
            ingredientFriedLevels[i] = ingredientFriedLevelSum / ingredientAmounts;
            ingredientProportions[i] = 1.0f * ingredientAmounts / dishSize;

            ingredientFryLevelGrade += (5.0f * (1.0f - (ingredientFriedLevels[i] / 
                currentRecipe.idealIngredientFriedLevels[i]))) / currentRecipe.ingredientIndexes.Count;
            ingredientProportionGrade += (5.0f * (1.0f - (ingredientProportions[i] / 
                currentRecipe.ingredientProportions[i]))) / currentRecipe.ingredientIndexes.Count;
        }

        dishSizeGrade = 5.0f*(1.0f - (1.0f*dishSize/currentRecipe.idealDishSize));

        ingredientProportions.Clear();
        ingredientFriedLevels.Clear();

        float grade = (ingredientFryLevelGrade + ingredientProportionGrade + 
            dishSizeGrade) / 3;
        Debug.Log("Your result: " + grade + "/5.0! Good job!");
        return grade;
    }
}

/*
    Ingredient indexes:
    0 - Bacon
    1 - Tomato
    2 - Mushroom
*/
