using System.Collections.Generic;
using UnityEngine;

namespace CameraControl
{
    public class CameraManager : MonoBehaviour
    {
        public InputManager inputManager;
        public Camera mainCamera;
        public List<CameraPoint> cameraPoints;
    
    
        private void OnEnable()
        {
            inputManager.cameraButtonPressed += OnCameraModeChanged;
            OnCameraModeChanged(1);
        }

        private void OnDisable()
        {
            inputManager.cameraButtonPressed -= OnCameraModeChanged;
        }

        private void OnCameraModeChanged(int mode)
        {
            for (var i = 0; i < cameraPoints.Count; i++)
            {
                var cameraPoint = cameraPoints[i];
                if (mode == i + 1)
                {
                    cameraPoint.StartMode(mainCamera);
                }
                else
                {
                    cameraPoint.StopMode();
                }
            }
        }
    }
}
