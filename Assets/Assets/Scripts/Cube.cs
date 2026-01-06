using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Color _defaultColor = Color.blue;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        SetDefaultValue();
    }

    public void SetDefaultValue()
    {
        GetComponent<Renderer>().material.color = _defaultColor;
        
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.Sleep();
    }
}