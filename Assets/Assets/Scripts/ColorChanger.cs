using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _punchColor = Color.red;
    [SerializeField] private CollisionDetector _collisionDetector;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _collisionDetector.Hit += ChangeColor;
    }

    private void OnDisable()
    {
        _collisionDetector.Hit -= ChangeColor;
    }

    private void ChangeColor()
    {
        _renderer.material.color = _punchColor;
        
        _collisionDetector.Hit -= ChangeColor;
    }
}