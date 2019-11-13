using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointTriggerHandler : MonoBehaviour
{
    private CustomVRButtonScript buttonScript;

    void Start()
    {
        buttonScript = GetComponentInParent<CustomVRButtonScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CustomButton"))
        {
            buttonScript.OnPressed();
        }
    }
}
