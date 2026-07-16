using System;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour
{
    public event Action CountChanged;
    
    public int CountActive { get; protected set; }
    public int CreatedCount { get; protected set; }
    public int SpawnedCount { get; protected set; }
    
    protected void InvokeCountChanged()
    {
        CountChanged?.Invoke();
    }
}
