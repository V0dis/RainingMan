using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour
{
    [SerializeField] private Color _defaultColor = Color.blue;

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (TryGetComponent(out _renderer))
        {
            SetDefaultValue();
        }
    }

    public void SetDefaultValue()
    {
        _renderer.material.color = _defaultColor;
        
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.Sleep();
    }
}