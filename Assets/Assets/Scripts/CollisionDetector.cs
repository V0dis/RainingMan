using UnityEngine;
using System;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string _targetTag = "Environment";
    
    public event Action Hit;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_targetTag))
            Hit?.Invoke();
    }
}