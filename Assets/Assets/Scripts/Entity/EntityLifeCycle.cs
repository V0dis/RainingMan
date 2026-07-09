using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EntityLifeCycle : MonoBehaviour
{
    [SerializeField] private float _allTime = 10;
    [SerializeField] private float _minReturnTime = 2;
    [SerializeField] private float _maxReturnTime = 5;
    
    private Coroutine _returnTimer;
    private Coroutine _deactivateTimer;
    
    public event Action<Entity> IsReadyToDeactivate;
    
    public void Initialize()
    {
        IsInitialized( );
        _returnTimer = StartCoroutine(DelayedReturn(_allTime));
    }

    protected void DelayedDeactivate()
    {
        if (_deactivateTimer != null) 
            return;
        
        if (_returnTimer != null) 
            StopCoroutine(_returnTimer);
        
        float returnTime = Random.Range(_minReturnTime, _maxReturnTime);
        
        _deactivateTimer = StartCoroutine(DelayedReturn(returnTime));
    }
    
    protected IEnumerator DelayedReturn(float time)
    {
        yield return new WaitForSeconds(time);

        Return();
        
        _deactivateTimer = null;
    }

    protected void Return()
    {
        _returnTimer = null;
        
        IsReadyToDeactivate?.Invoke(GetComponent<Entity>());
    }

    protected virtual void IsInitialized() { }
}