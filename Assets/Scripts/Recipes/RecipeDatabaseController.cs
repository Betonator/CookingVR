using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDatabaseController : MonoBehaviour
{
    private List<Recipe> recipeList;
    public Recipe currentRecipe;
    [SerializeField]
    private RecipeCheckArea checkArea;
    [SerializeField]
    private Text recipeText;

    private Dictionary<int, string> ingredientTypes;

    private int dishSize;
    public float currentGrade = 0.0f;

    void Awake()
    {
        BuildRecipeList();
        BuildIngredientDictionary();
    }

    private void Start()
    {
        SetCurrentRecipe(2); //later to be removed
        UpdateRecipeText();
    }

    private void Update() //later to be removed
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckDish();
        }
    }

    void BuildIngredientDictionary()
    {
        ingredientTypes = new Dictionary<int, string>()
        {
            { 0, "Bacon" },
            { 1, "Cucumber" },
            { 2, "Mushroom" }
        };
    }

    void BuildRecipeList()
    {
        recipeList = new List<Recipe>()
        {
            new Recipe("BaconCucumber", //name
            new List<int>{ 0, 1 }, //ingredient indexes
            new List<float>{ 80f, 90f}, //ingredient ideal fried levels
            new List<float>{ 0.4f, 0.6f}, //ingredient proportions (make sure the sum is 1)
            2500), //ideal dish size
            new Recipe("BaconMushroom",
            new List<int>{ 0, 2 },
            new List<float>{ 60f, 80f},
            new List<float>{ 0.5f, 0.5f},
            1500),
            new Recipe("CucumberMushroom",
            new List<int>{ 1, 2 },
            new List<float>{ 50f, 70f},
            new List<float>{ 0.3f, 0.7f},
            2000)
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

    public void CheckDish()
    {
        dishSize = checkArea.ingredients.Count;

        float ingredientFryLevelGrade = 0f;
        float ingredientProportionGrade = 0f;
        float dishSizeGrade = 0f;
        float ingredientFriedLevelSum;
        float ingredientAmounts;
        float ingredientProportions;
        float ingredientFriedLevels;

        for (int i = 0; i < currentRecipe.ingredientIndexes.Count; i++)
        {
            ingredientProportions = 0f;
            ingredientFriedLevels = 0f;
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
            if(ingredientAmounts == 0){ ingredientFriedLevels = 0;
                ingredientProportions = 0;
            }
            else { ingredientFriedLevels = ingredientFriedLevelSum / ingredientAmounts;
                ingredientProportions = 1.0f * ingredientAmounts / dishSize;
            }

            ingredientFryLevelGrade += (5.0f * (1.0f - ((currentRecipe.idealIngredientFriedLevels[i] - ingredientFriedLevels) / 
                currentRecipe.idealIngredientFriedLevels[i]))) / currentRecipe.ingredientIndexes.Count;
            ingredientProportionGrade += (5.0f * (1.0f - ((currentRecipe.ingredientProportions[i] - ingredientProportions) / 
                currentRecipe.ingredientProportions[i]))) / currentRecipe.ingredientIndexes.Count;
        }

        dishSizeGrade = 5.0f*(1.0f - (1.0f*(currentRecipe.idealDishSize - dishSize) / currentRecipe.idealDishSize));

        float grade = (ingredientFryLevelGrade + ingredientProportionGrade + 
            dishSizeGrade) / 3;
        Debug.Log("Your result: " + grade + "/5.0! Good job!");
        currentGrade = grade;
        UpdateRecipeText(grade);
    }

    public void UpdateRecipeText()
    {
        recipeText.text = "Current recipe: " + currentRecipe.recipeName;
        for (int i = 0; i < currentRecipe.ingredientIndexes.Count; i++)
        {
            recipeText.text += "\n" + (currentRecipe.ingredientProportions[i]).ToString() + " " +
                ingredientTypes[currentRecipe.ingredientIndexes[i]] + ", " +
                (currentRecipe.idealIngredientFriedLevels[i]).ToString() + "% done";
        }
        recipeText.text += "\nIdeal size: " + currentRecipe.idealDishSize.ToString() + " pieces";
    }

    public void UpdateRecipeText(float grade)
    {
        recipeText.text = "Current recipe: " + currentRecipe.recipeName;
        for (int i = 0; i < currentRecipe.ingredientIndexes.Count; i++)
        {
            recipeText.text += "\n" + (currentRecipe.ingredientProportions[i]).ToString() + " " +
                ingredientTypes[currentRecipe.ingredientIndexes[i]] + ", " +
                (currentRecipe.idealIngredientFriedLevels[i]).ToString() + "% done";
        }
        recipeText.text += "\nIdeal size: " + currentRecipe.idealDishSize.ToString() + " pieces";
        recipeText.text += "\nYour grade:\n" + grade.ToString() + "/5.0\nGood job! :)";
    }
}
