using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] SpringJoint currentPlayerSpringJoint;
    [SerializeField] float detachDelay;
    [SerializeField] GameObject virtualCamera;
    //[SerializeField] GameObject thinkingBaloons;

    private Rigidbody currentPlayerRigidbody;
    private Camera mainCamera;
    private float defaultPlayerYPos;
    private float playerZDistance;
    private Vector3 screenPosition;
    private bool isDragging;

    void Start()
    {
        currentPlayerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        defaultPlayerYPos = currentPlayerRigidbody.position.y;
        mainCamera = Camera.main;
        virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        playerZDistance = currentPlayerRigidbody.transform.position.z - mainCamera.transform.position.z;

    }

    void Update()
    {
        ProcessTracking();
    }

    void ProcessTracking()
    {
        if (currentPlayerRigidbody == null) { return; }

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                //currentPlayerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
                ThrowPlayer();
            }

            isDragging = false;

            return;
        }
        
        //thinkingBaloons.SetActive(false);

        isDragging = true;
        currentPlayerRigidbody.isKinematic = true;

        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        screenPosition = new Vector3(touchPos.x, touchPos.y, playerZDistance);

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPosition);
        worldPos.z += worldPos.y;
        worldPos.y = defaultPlayerYPos;
        currentPlayerRigidbody.position = worldPos;
    }

    private void ThrowPlayer()
    {
        currentPlayerRigidbody.isKinematic = false;
        currentPlayerRigidbody = null;

        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall()
    {
        currentPlayerSpringJoint.gameObject.SetActive(false);
        GameObject.Find("FrictionHandler").GetComponent<FrictionHandler>().enabled = true;
    }
}
