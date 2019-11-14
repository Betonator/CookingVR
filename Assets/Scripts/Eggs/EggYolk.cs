using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggYolk : MonoBehaviour
{

    public float forceStrength = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Yolk")
        {
            Vector3 relativePosition = collision.transform.position - transform.position;
            GetComponent<Rigidbody>().AddForce(relativePosition * forceStrength);
        }
    }
}
