using UnityEngine;
using System;

public class CollisionDetector : MonoBehaviour
{
    public event Action Hit;
    
    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.GetComponent<TriggerPlatform>() != null)
            Hit?.Invoke();
    }
}