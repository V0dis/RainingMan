using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CubeLifeCycle : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private float _allTime = 10;
    [SerializeField] private float _minReturnTime = 2;
    [SerializeField] private float _maxReturnTime = 5;
    
    public UnityEvent<Cube> isReadyToDeactivate = new();

    private Coroutine _returnTimer;
    private Coroutine _fullTimer;
    
    private void OnEnable()
    {
        _collisionDetector.Hit += DeactivateCube;

        _fullTimer = StartCoroutine(DelayedReturn(_allTime));
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
        
        isReadyToDeactivate?.Invoke(GetComponent<Cube>());
        
        _returnTimer = null;
    }
}
