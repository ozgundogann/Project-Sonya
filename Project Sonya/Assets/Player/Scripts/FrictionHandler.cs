using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrictionHandler : MonoBehaviour
{    
    private void Awake() {
        this.enabled = false;
    }
    void Update() 
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("I'm pressed!!!");
        }
    }
}
