using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    public Action onPausePressed;
    
    public Action onBoostStarted;
    public Action onBoostCanceled;
    
    public Action<int> cameraButtonPressed;

    public Action<float> onVerticalStarted;
    public Action<float> onVerticalPerformed;
    public Action<float> onVerticalCanceled;
    
    public Action<Vector2> onHorizontalStarted;
    public Action<Vector2> onHorizontalPerformed;
    public Action<Vector2> onHorizontalCanceled;
    
    public Action<float> onRotationStarted;
    public Action<float> onRotationPerformed;
    public Action<float> onRotationCanceled;

    private void Awake()
    {
        inputActionAsset.FindAction("Pause").performed += OnPausePerformed;
        inputActionAsset.FindAction("Boost").started += OnBoostStarted;
        inputActionAsset.FindAction("Boost").canceled += OnBoostCanceled;
        
        inputActionAsset.FindAction("1").performed += OnOnePerformed;
        inputActionAsset.FindAction("2").performed += OnTwoPerformed;
        inputActionAsset.FindAction("3").performed += OnThreePerformed;
        
        inputActionAsset.FindAction("Vertical").started += OnVerticalStarted;
        inputActionAsset.FindAction("Vertical").performed += OnVerticalPerformed;
        inputActionAsset.FindAction("Vertical").canceled += OnVerticalCanceled;

        inputActionAsset.FindAction("Horizontal").started += OnHorizontalStarted;
        inputActionAsset.FindAction("Horizontal").performed += OnHorizontalPerformed;
        inputActionAsset.FindAction("Horizontal").canceled += OnHorizontalCanceled;

        inputActionAsset.FindAction("Rotation").started += OnRotationStarted;
        inputActionAsset.FindAction("Rotation").performed += OnRotationPerformed;
        inputActionAsset.FindAction("Rotation").canceled += OnRotationCanceled;
    }

    private void OnDestroy()
    {
        inputActionAsset.FindAction("Pause").performed -= OnPausePerformed;
        
        inputActionAsset.FindAction("Boost").started -= OnBoostStarted;
        inputActionAsset.FindAction("Boost").canceled -= OnBoostCanceled;
        
        inputActionAsset.FindAction("1").performed -= OnOnePerformed;
        inputActionAsset.FindAction("2").performed -= OnTwoPerformed;
        inputActionAsset.FindAction("3").performed -= OnThreePerformed;
        
        inputActionAsset.FindAction("Vertical").started -= OnVerticalStarted;
        inputActionAsset.FindAction("Vertical").performed -= OnVerticalPerformed;
        inputActionAsset.FindAction("Vertical").canceled -= OnVerticalCanceled;
        
        inputActionAsset.FindAction("Horizontal").started -= OnHorizontalStarted;
        inputActionAsset.FindAction("Horizontal").performed -= OnHorizontalPerformed;
        inputActionAsset.FindAction("Horizontal").canceled -= OnHorizontalCanceled;
        
        inputActionAsset.FindAction("Rotation").started -= OnRotationStarted;
        inputActionAsset.FindAction("Rotation").performed -= OnRotationPerformed;
        inputActionAsset.FindAction("Rotation").canceled -= OnRotationCanceled;
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        onPausePressed?.Invoke();
    }

    private void OnOnePerformed(InputAction.CallbackContext context)
    {
        cameraButtonPressed?.Invoke(1);
    }

    private void OnTwoPerformed(InputAction.CallbackContext context)
    {
        cameraButtonPressed?.Invoke(2);
    }

    private void OnThreePerformed(InputAction.CallbackContext context)
    {
        cameraButtonPressed?.Invoke(3);
    }

    private void OnVerticalStarted(InputAction.CallbackContext context)
    {
        onVerticalStarted?.Invoke(context.ReadValue<float>());
    }

    private void OnVerticalPerformed(InputAction.CallbackContext context)
    {
        onVerticalPerformed?.Invoke(context.ReadValue<float>());
    }

    private void OnVerticalCanceled(InputAction.CallbackContext context)
    {
        onVerticalCanceled?.Invoke(context.ReadValue<float>());
    }

    private void OnHorizontalStarted(InputAction.CallbackContext context)
    {
        onHorizontalStarted?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnHorizontalPerformed(InputAction.CallbackContext context)
    {
        onHorizontalPerformed?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnHorizontalCanceled(InputAction.CallbackContext context)
    {
        onHorizontalCanceled?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnRotationStarted(InputAction.CallbackContext context)
    {
        onRotationStarted?.Invoke(context.ReadValue<float>());
    }

    private void OnRotationPerformed(InputAction.CallbackContext context)
    {
        onRotationPerformed?.Invoke(context.ReadValue<float>());
    }

    private void OnRotationCanceled(InputAction.CallbackContext context)
    {
        onRotationCanceled?.Invoke(context.ReadValue<float>());
    }

    private void OnBoostStarted(InputAction.CallbackContext context)
    {
        onBoostStarted?.Invoke();
    }

    private void OnBoostCanceled(InputAction.CallbackContext context)
    {
        onBoostCanceled?.Invoke();
    }
}
