using System;
using System.Collections.Generic;
using UnityEngine;

public class PropellersRotation : MonoBehaviour
{
    public GameManager gameManager;
    public float fansSpeed = 20f;
    public List<Transform> fans = new();

    public void FixedUpdate()
    {
        PropellerRotation();
    }

    public void PropellerRotation()
    {
        if (gameManager != null && gameManager.gameStateType == GameStateType.Gameplay)
        {
            foreach (var fan in fans)
            {
                fan.Rotate(Vector3.up*(fansSpeed*Time.deltaTime), Space.Self);
            }
        }
        
    }
    
    
    
    
    
}
