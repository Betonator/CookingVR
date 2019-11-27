using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choppable : MonoBehaviour
{
    public int childAmount = 4;
    public int choppedStage = 1;
    public int maxChoppedStage = 4;
    public float invincibilityInterval = 1.0f;
    private float invincibilityTimer;
    private bool notChoppable;
    BoxCollider chopCollider;
    // Start is called before the first frame update
    void Start()
    {
        invincibilityTimer = invincibilityInterval;
        notChoppable = true;
        chopCollider = GetComponent<BoxCollider>();
    }

	// Update is called once per frame
	void Update()
	{
        if (notChoppable)
        {
            invincibilityTimer -= Time.deltaTime;
            if(invincibilityTimer <= 0.0f)
            {
                notChoppable = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            if (!notChoppable)
            {
                GameObject newChild = Instantiate(this.gameObject);
                //newChild.transform.position = new Vector3();
                //newChild.GetComponent<Choppable>().choppedStage = choppedStage + 1;
                //Destroy(this.gameObject);
            }
        }
    }
}

