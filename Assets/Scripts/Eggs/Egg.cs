using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
            GameObject eggRawEx = PrefabUtility.InstantiatePrefab(eggRaw) as GameObject;
            eggRawEx.transform.position = this.transform.position;
            Destroy(this);
        }
    }
}
