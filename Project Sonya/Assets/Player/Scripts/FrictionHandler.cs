using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrictionHandler : MonoBehaviour
{
    [SerializeField] float frictionRateFalling = 20f;
    [SerializeField] float frictionRateRising = 0.01f;
    
    PhysicMaterial playerPhysicMaterial;
    float frictionMaxVal;
    float frictionMinVal = 0.1f;

    void Awake()
    {
        this.enabled = false;
        playerPhysicMaterial = GameObject.Find("Player").GetComponent<Collider>().material;
        playerPhysicMaterial.dynamicFriction = 0;
        frictionMaxVal = 0.6f;
    }

    void LateUpdate() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerPhysicMaterial.dynamicFriction = Mathf.Clamp(playerPhysicMaterial.dynamicFriction - (Time.fixedDeltaTime * frictionRateFalling), 0.01f, 0.6f);
        }
        else if(playerPhysicMaterial.dynamicFriction < frictionMaxVal)
        {
            playerPhysicMaterial.dynamicFriction += frictionRateRising * Time.fixedDeltaTime ;
        }
          
    }
    
}
