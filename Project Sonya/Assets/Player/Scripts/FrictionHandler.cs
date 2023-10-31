using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrictionHandler : MonoBehaviour
{
    [SerializeField] float frictionRateFalling = 15f;
    [SerializeField] float frictionRateRising = 0.03f;
    [SerializeField] float frictionMaxVal;
    
    PhysicMaterial playerPhysicMaterial;
    float frictionMinVal = 0.01f;

    void Awake()
    {
        playerPhysicMaterial = GameObject.Find("Player").GetComponent<Collider>().material;
        playerPhysicMaterial.dynamicFriction = frictionMaxVal;
        this.enabled = false;
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerPhysicMaterial.dynamicFriction = 
                Mathf.Clamp(playerPhysicMaterial.dynamicFriction - frictionRateFalling * Time.fixedDeltaTime, frictionMinVal, frictionMaxVal);
        }
        else if(playerPhysicMaterial.dynamicFriction < frictionMaxVal)
        {
            playerPhysicMaterial.dynamicFriction += frictionRateRising * Time.fixedDeltaTime ;
        }
          
    }
    
}
