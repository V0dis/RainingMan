using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _punchColor = Color.red;
    [SerializeField] private CollisionDetector _collisionDetector;

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
        GetComponent<Renderer>().material.color = _punchColor;
    }
}