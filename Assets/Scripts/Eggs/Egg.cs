using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject eggRaw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Skillet")
        {
            GameObject Egg = Instantiate(eggRaw) as GameObject;
            Egg.transform.parent = collision.transform;
            Egg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            Destroy(this.gameObject);
        }
    }
}
