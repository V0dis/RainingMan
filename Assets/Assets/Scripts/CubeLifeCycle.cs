using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CubeLifeCycle : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private float _allTime = 10;
    [SerializeField] private float _minReturnTime = 2;
    [SerializeField] private float _maxReturnTime = 5;
    
    private Coroutine _returnTimer;
    
    public event Action<Cube> IsReadyToDeactivate;
    
    private void OnEnable()
    {
        _collisionDetector.Hit += DeactivateCube;

        StartCoroutine(DelayedReturn(_allTime));
    }

    private void OnDisable()
    {
        _collisionDetector.Hit -= DeactivateCube;
    }

    private void DeactivateCube()
    {
        if (_returnTimer != null) 
            return;
        
        float returnTime = Random.Range(_minReturnTime, _maxReturnTime + 1);
        
        _returnTimer = StartCoroutine(DelayedReturn(returnTime));
    }

    private IEnumerator DelayedReturn(float time)
    {
        yield return new WaitForSeconds(time);
        
        IsReadyToDeactivate?.Invoke(GetComponent<Cube>());
        
        _returnTimer = null;
    }
}
