using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choppable : MonoBehaviour
{
    public int childAmount = 2;
    public int choppedStage = 1;
    public int maxChoppedStage = 4;
    public float invincibilityInterval = 1.0f;
    private float invincibilityTimer;
    private bool choppable;
    private float scaleOfChilds = 0.01f;
    BoxCollider chopCollider;
    // Start is called before the first frame update
    void Start()
    {
        invincibilityTimer = invincibilityInterval;
        choppable = false;
        chopCollider = GetComponent<BoxCollider>();
    }

	// Update is called once per frame
	void Update()
	{
        if (!choppable)
        {
            invincibilityTimer -= Time.deltaTime;
            if(invincibilityTimer <= 0.0f)
            {
                choppable = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            if (choppable && (this.choppedStage < maxChoppedStage))
            {
                for (int i = 0; i < childAmount; i++)
                {
                    GameObject newChild = Instantiate(this.gameObject);
                    newChild.transform.position = this.transform.position;
                    newChild.transform.localScale -= newChild.transform.localScale * 0.2f;
                    newChild.GetComponent<Choppable>().choppedStage = choppedStage + 1;
                    newChild.GetComponent<Ingredient>().OnSpawn();
                }
                Skillet.ingredients.Remove(this.GetComponent<Ingredient>());
                Destroy(this.gameObject);
            }
        }
    }
}

