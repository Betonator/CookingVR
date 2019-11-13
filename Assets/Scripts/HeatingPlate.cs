using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatingPlate : MonoBehaviour
{
    private float currentHeat;
    public float maxHeat = 100f;

    private WorkingState state;
    private enum WorkingState
    {
        Idle,
        Heating
    }

    void Start()
    {
        state = WorkingState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case WorkingState.Idle:
                //cool down and stop fire function
                break;
            case WorkingState.Heating:
                //heat upp and call fire function
                break;
        }
    }

    public void PowerSwitch()
    {
        if(state == WorkingState.Idle)
        {
            state = WorkingState.Heating;
            Debug.Log("Stove on!");
        }
        else if (state == WorkingState.Heating)
        {
            state = WorkingState.Idle;
            Debug.Log("Stove off!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
