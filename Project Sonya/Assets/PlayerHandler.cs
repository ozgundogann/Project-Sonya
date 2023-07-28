using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] Rigidbody currentPlayerRigidbody;
    [SerializeField] SpringJoint currentPlayerSpringJoint;
    [SerializeField] float detachDelay;
    [SerializeField] GameObject virtualCamera;

    private Camera mainCamera;
    private float cameraZDistance;
    private Vector3 screenPosition;
    private bool isDragging;

    void Start()
    {
        mainCamera = Camera.main;
        cameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
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
                currentPlayerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
                ThrowPlayer();
            }

            isDragging = false;

            return;
        }

        isDragging = true;
        currentPlayerRigidbody.isKinematic = true;

        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        screenPosition = new Vector3(touchPos.x, touchPos.y, cameraZDistance);

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPosition);
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
    }
}
