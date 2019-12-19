using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillet : MonoBehaviour
{
    [SerializeField] private float currentHeat;
    public float deHeatingFactor = 0.2f;

    public HeatingPlate plate;

    public static List<Ingredient> ingredients = new List<Ingredient>();

    void Update()
    {
        if (plate != null && ingredients.Count != 0)
        {
            currentHeat = plate.currentHeat;
        }
        else
        {
            currentHeat -= Time.deltaTime * deHeatingFactor;
        }
        Fry(currentHeat);
    }

    private void Fry(float heat)
    {
        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.IngredientFry(heat);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            ingredients.Add(other.GetComponent<Ingredient>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            ingredients.Remove(other.GetComponent<Ingredient>());
        }
    }
}
