using UnityEngine;

public class CubeLifeCycle : EntityLifeCycle
{
    [SerializeField] private CollisionDetector _collisionDetector;

    private void OnEnable()
    {
        _collisionDetector.Hit += DelayedDeactivate;
    }

    private void OnDisable()
    { 
        _collisionDetector.Hit -= DelayedDeactivate;
    }
}
