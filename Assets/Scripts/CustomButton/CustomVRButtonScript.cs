using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomVRButtonScript : MonoBehaviour
{
    public UnityEvent functionToCall = new UnityEvent();

    public void OnPressed()
    {
        functionToCall.Invoke();
    }
}
