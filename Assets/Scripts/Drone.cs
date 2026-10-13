using System;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public InputManager inputManager; 

    public Vector3 velocity;
    public Rigidbody rb;
    [Header("Visual Tilt Settings")]
    public Transform droneModel; 
    public float maxTiltAngle = 25f;
    public float tiltSpeed = 5f;
    [Header("Boost Settings")]
    public float boostMultiplier = 2f;
    private bool isBoosting = false;
    
    public float verticalAcceleration;
    public float horizontalAcceleration;
    public float rotationSpeed;
    public float verticalDrag;
   

    void FixedUpdate()
    {
        if (rb.isKinematic) return;
        ApplyMovement();
        ApplyRotation();
        ApplyStabilization();
        ApplyModelTilt();
        

        velocity = rb.linearVelocity;
    }
    public float horizontalDrag;

    private float verticalInput;
    private Vector2 horizontalInput;
    private float rotationInput;

    private void OnEnable()
    {
        inputManager.onBoostStarted += OnBoostStarted;
        inputManager.onBoostCanceled += OnBoostCanceled;
        
        inputManager.onVerticalStarted += OnVerticalStarted;
        inputManager.onVerticalPerformed += OnVerticalPerformed;
        inputManager.onVerticalCanceled += OnVerticalCanceled;
        
        inputManager.onHorizontalStarted += OnHorizontalStarted;
        inputManager.onHorizontalPerformed += OnHorizontalPerformed;
        inputManager.onHorizontalCanceled += OnHorizontalCanceled;
        
        inputManager.onRotationStarted += OnRotationStarted;
        inputManager.onRotationPerformed += OnRotationPerformed;
        inputManager.onRotationCanceled += OnRotationCanceled;
    }

    private void OnDisable()
    {
        inputManager.onBoostStarted -= OnBoostStarted;
        inputManager.onBoostCanceled -= OnBoostCanceled;
        
        inputManager.onVerticalStarted -= OnVerticalStarted;
        inputManager.onVerticalPerformed -= OnVerticalPerformed;
        inputManager.onVerticalCanceled -= OnVerticalCanceled;
        
        inputManager.onHorizontalStarted -= OnHorizontalStarted;
        inputManager.onHorizontalPerformed -= OnHorizontalPerformed;
        inputManager.onHorizontalCanceled -= OnHorizontalCanceled;
                
        inputManager.onRotationStarted -= OnRotationStarted;
        inputManager.onRotationPerformed -= OnRotationPerformed;
        inputManager.onRotationCanceled -= OnRotationCanceled;
    }
    private void OnBoostStarted()
    {
        isBoosting = true;
    }

    private void OnBoostCanceled()
    {
        isBoosting = false;
    }

    private void OnHorizontalStarted(Vector2 vector)
    {
        horizontalInput = vector;
    }
    
    private void OnHorizontalPerformed(Vector2 vector)
    {
        horizontalInput = vector;
    }
    
    private void OnHorizontalCanceled(Vector2 vector)
    {
        horizontalInput = Vector2.zero;
    }

    private void OnVerticalStarted(float value)
    {
        verticalInput = value;
    }
    
    private void OnVerticalPerformed(float value)
    {
        verticalInput = value;
    }
    
    private void OnVerticalCanceled(float value)
    {
        verticalInput = 0;
    }

    private void OnRotationStarted(float value)
    {
        rotationInput = value;
    }

    private void OnRotationPerformed(float value)
    {
        rotationInput = value;
    }

    private void OnRotationCanceled(float value)
    {
        rotationInput = 0;
    }

    private void ApplyMovement()
    {
        
        float currentHorizontalAcc = isBoosting ? horizontalAcceleration * boostMultiplier : horizontalAcceleration;
        float currentVerticalAcc = isBoosting ? verticalAcceleration * boostMultiplier : verticalAcceleration;

        Vector3 horizontalDirection = transform.right * horizontalInput.x + transform.forward * horizontalInput.y;
        Vector3 horizontalForce = horizontalDirection * currentHorizontalAcc;
        
        Vector3 verticalForce = Vector3.up * (verticalInput * currentVerticalAcc);
        
        rb.AddForce(horizontalForce + verticalForce, ForceMode.Acceleration);
    }
    private void ApplyRotation()
    {
        if (rb.isKinematic) return;

       
        if (Mathf.Abs(rotationInput) > 0.01f)
        {
            float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
            var deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
       
        else if (Camera.main != null)
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f; 

           
            if (cameraForward.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward.normalized);
                
               
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 5f));
            }
        }
    }

    

    

    private void ApplyStabilization()
    {
        Vector3 linearVelocity = rb.linearVelocity;
        
        Vector3 horizontalVelocity = new Vector3(linearVelocity.x, 0, linearVelocity.z);
        Vector3 horizontalBrake = -horizontalVelocity * horizontalDrag;
        Vector3 verticalBrake = Vector3.up * (-linearVelocity.y * verticalDrag);
        
        rb.AddForce(horizontalBrake + verticalBrake, ForceMode.Acceleration);
    }

    public void OnReset()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        if (droneModel != null)
        {
            droneModel.localRotation = Quaternion.identity; 
        }
    }

    public void OnGameplay()
    {
        
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
    }
    private void ApplyModelTilt()
    {
        if (droneModel == null) return; 

     
        float targetPitch = horizontalInput.y * maxTiltAngle;
        float targetRoll = -horizontalInput.x * maxTiltAngle;
        Quaternion targetRotation = Quaternion.Euler(targetPitch, 0f, targetRoll);
        droneModel.localRotation = Quaternion.Slerp(droneModel.localRotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
    }
}