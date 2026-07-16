using System.Collections.Generic;
using UnityEngine;

public abstract class PoolEntity<T> : PoolBase where T : Entity
{
    [SerializeField] private T _entityPrefab;
        
    private Stack<T> _poolEntity = new Stack<T>();
    private int _poolSize = 10;
    
    protected void Initialize(T prefab)
    {
        _entityPrefab = prefab;
        CreatePool();
    }

    public T Get()
    {
        if (_poolEntity.Count == 0)
            CreateEntity();
        
        T entity = _poolEntity.Pop();
        
        CountActive++;
        SpawnedCount++;
        InvokeCountChanged();
        
        return entity;
    }
    
    public void ReturnToPool(T entity)
    {
       _poolEntity.Push(entity);
       
       CountActive--;
       InvokeCountChanged();
    }
    
    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
            CreateEntity();
    }

    private void CreateEntity()
    {
        T instance = Instantiate(_entityPrefab);
        
        instance.gameObject.SetActive(false);
        
        _poolEntity.Push(instance);
        
        CreatedCount++;
        InvokeCountChanged();
    }
}