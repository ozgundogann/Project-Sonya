using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrictionHandler : MonoBehaviour
{
    [SerializeField] PhysicMaterial physicMaterial;
    [SerializeField] float frictionMaxVal = 2f;
    [SerializeField] float frictionMinVal = 0.1f;
    [SerializeField] float frictionVal = 2f;
    [SerializeField] float frictionRateFalling = 0.8f;
    [SerializeField] float frictionRateRising = 1.002f;

    void Awake()
    {
        this.enabled = false;
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            frictionVal = Mathf.Clamp(frictionVal * frictionRateFalling, frictionMinVal, frictionMaxVal);
            physicMaterial.dynamicFriction = frictionVal;
            //Debug.Log("Decreasing" + physicMaterial.dynamicFriction);
        }
        else
        {
            frictionVal = Mathf.Clamp(frictionVal * frictionRateRising, frictionMinVal, frictionMaxVal);
            physicMaterial.dynamicFriction = frictionVal;
            //Debug.Log("Increasing" + physicMaterial.dynamicFriction);
        }    
    }

    
}
