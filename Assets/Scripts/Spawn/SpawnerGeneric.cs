using UnityEngine;

public class SpawnerGeneric<T> : MonoBehaviour where T : Entity
{
    [SerializeField] protected PoolEntity<T> PoolEntity;
    
    protected void ConfigureEntity(ref T entity)
    {
        entity.gameObject.SetActive(true);
        
        if (entity.TryGetComponent<EntityLifeCycle>(out var lifeCycle))
            lifeCycle.Initialize();
        
        Subscribe(entity);
    }

    private void Subscribe(T entity)
    {
        if (entity.TryGetComponent(out EntityLifeCycle lifeCycle))
            lifeCycle.IsReadyToDeactivate += Return;
    }

    private void Unsubscribe(T entity)
    {
        if (entity.TryGetComponent(out EntityLifeCycle lifeCycle))
            lifeCycle.IsReadyToDeactivate -= Return;
    }

    private void Return(Entity entity)
    {
        if (entity is T typeEntety)
        {
            if (typeEntety.gameObject.activeSelf == false)
                return;
            
            OnReturning(typeEntety);
            
            typeEntety.SetDefaultValue();
            Unsubscribe(typeEntety);
            typeEntety.gameObject.SetActive(false);
            
            PoolEntity.ReturnToPool(typeEntety);
        }
    }

    protected virtual void OnReturning(T entity){ }
}