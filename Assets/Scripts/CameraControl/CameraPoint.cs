using UnityEngine;

namespace CameraControl
{
    public class CameraPoint : MonoBehaviour
    {
        public CameraFollowMode cameraFollowMode;
        public Transform target;
        private bool isStarted;
        public Vector3 targetOffset;
        
        public float mouseSensitivity = 3f;
        private float mouseY;
        private float mouseX;
        
    
        public void StartMode(Camera targetCamera)
        {
            isStarted = true;
            targetCamera.transform.SetParent(transform);
            targetCamera.transform.localPosition = Vector3.zero;
            targetCamera.transform.localEulerAngles = Vector3.zero;
            
            Vector3 angles = transform.eulerAngles;
            mouseX = angles.y;
            mouseY = angles.x;
        }

        public void StopMode()
        {
            isStarted = false;
        }

        private void Update()
        {
            if (isStarted && cameraFollowMode == CameraFollowMode.Follow)
            {
                transform.position = target.position - target.forward * targetOffset.z + target.up * targetOffset.y;
                transform.rotation = target.rotation;
            }
            else if (cameraFollowMode == CameraFollowMode.FreeLook)
            {
                mouseX += Input.GetAxis("Mouse X") * mouseSensitivity ;
                mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                mouseY = Mathf.Clamp(mouseY, -30f, 60f);
                
                Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
                
                Vector3 position = target.position + rotation * new Vector3(0, targetOffset.y, -targetOffset.z);

                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }
}
