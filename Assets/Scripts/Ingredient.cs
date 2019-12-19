using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private Collider ingredientCollider;
    private Rigidbody ingredientBody;
    private float fryingFactor;
    private float shizzleForceFactor;
    private float shizzleTimer;

    public int ingredientNameIndex;
    public float currentFriedLevel;
    public float maxFriedLevel;
    public float additionalFryingScale;
    public float shizzleForceScale;
    public float shizzleInterval;

    private void Start()
    {
        OnSpawn();
    }

    public void OnSpawn()
    {
        ingredientCollider = GetComponent<Collider>();
        ingredientBody = GetComponent<Rigidbody>();
        UpdateFactors();
        shizzleTimer = Random.Range(0.0f, shizzleInterval);
    }

    public void IngredientFry(float heat)
    {
        currentFriedLevel += Time.deltaTime * fryingFactor * heat;
        Shizzle(heat);
    }

    private void Shizzle(float heat)
    {
        shizzleTimer -= Time.deltaTime;
        if(shizzleTimer <= 0.0f)
        {
            shizzleTimer = Random.Range(0.0f, shizzleInterval);
            ingredientBody.AddForce(Vector3.up*shizzleForceFactor*heat, ForceMode.Impulse);
        }
    }

    public void UpdateFactors()
    {
        fryingFactor = (ingredientCollider.bounds.size.x +
            ingredientCollider.bounds.size.y + ingredientCollider.bounds.size.z) / 3 * additionalFryingScale;
        shizzleForceFactor = ingredientBody.mass * shizzleForceScale;
    }
}
