using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolEntity : MonoBehaviour
{
    private Entity _entityPrefab;
    private Stack<Entity> _poolEntity = new Stack<Entity>();
    private int _poolSize = 10;
    
    public event Action CountChanged;
    
    public int CountActive { get; private set; }
    public int CreatedCount { get; private set; }
    public int SpawnedCount { get; private set; }
    
    protected void Initialize(Entity prefab)
    {
        _entityPrefab = prefab;
        CreatePool();
    }

    public Entity Get()
    {
        if (_poolEntity.Count == 0)
            CreateEntity();
        
        Entity entity = _poolEntity.Pop();
        
        CountActive++;
        SpawnedCount++;
        CountChanged?.Invoke();
        
        return entity;
    }
    
    public void Return(Entity entity)
    {
       _poolEntity.Push(entity);
       
       CountActive--;
    }
    
    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
            CreateEntity();
    }

    private void CreateEntity()
    {
        Entity instance = Instantiate(_entityPrefab);
        
        instance.gameObject.SetActive(false);
        
        _poolEntity.Push(instance);
        
        CreatedCount++;
        
        CountChanged?.Invoke();
    }
}