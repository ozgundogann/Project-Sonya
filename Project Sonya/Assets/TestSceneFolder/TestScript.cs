using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    private Camera mainCamera;
    
    void Start() 
    {
        mainCamera = Camera.main;
    }
    
    void Update() 
    {
        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 worldPos = mainCamera.ScreenToViewportPoint(touchPos);
        Debug.Log(worldPos);
    }
}
