using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatingPlate : MonoBehaviour
{
    public float currentHeat;
    public float maxHeat = 100f;
    public float heatingFactor = 0.2f;

    private MeshRenderer plateRenderer;

    [SerializeField]
    private WorkingState state;
    private enum WorkingState
    {
        Idle,
        Heating
    }

    void Start()
    {
        state = WorkingState.Idle;
        currentHeat = 0;
        plateRenderer = GetComponent<MeshRenderer>();
        Mathf.Clamp(currentHeat,0.0f,maxHeat);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case WorkingState.Idle:
                //cool down and signalize it
                currentHeat -= Time.deltaTime * heatingFactor/2;
                break;
            case WorkingState.Heating:
                //heat upp and signalize it
                currentHeat += Time.deltaTime * heatingFactor/2;
                break;
        }
        currentHeat = Mathf.Clamp(currentHeat, 0.0f, maxHeat);
        UpdateMesh();
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

    private void UpdateMesh()
    {
        plateRenderer.material.SetColor("_BaseColor", new Color(currentHeat / maxHeat, 0f, 0f, 1f));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Skillet"))
        {
            collision.GetComponent<Skillet>().plate = this;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Skillet"))
        {
            collision.GetComponent<Skillet>().plate = null;
        }
    }
}
