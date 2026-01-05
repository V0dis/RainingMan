using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Color _defaultColor = Color.blue;

    private void Awake()
    {
        SetDefaultValue();
    }

    public void SetDefaultValue()
    {
        if (GetComponent<Renderer>() != null)
            GetComponent<Renderer>().material.color = _defaultColor;
    
        var rigidbody = GetComponent<Rigidbody>();
        
        if (rigidbody)
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.Sleep();
        }
    }
}