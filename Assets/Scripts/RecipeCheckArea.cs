using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCheckArea : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

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
