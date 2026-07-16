using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : SpawnerGeneric<Cube>
{
    [SerializeField] private float _interval = 2f;
    [SerializeField] private float _radiusSpawn = 5f;
    
    private Coroutine _spawnRoutine;
    
    public event Action<Cube> IsReturning;
    
    private void Start()
    {
        _spawnRoutine = StartCoroutine(SpawnLoopCubes());
    }

    protected override void OnReturning(Cube cube)
    {
        IsReturning?.Invoke(cube);
    }

    private IEnumerator SpawnLoopCubes()
    {
        var wait = new WaitForSeconds(_interval);
        
        while (enabled)
        {
            Cube cube = PoolEntity.Get();
            
            cube.transform.rotation = Quaternion.identity;
            cube.transform.position = SelectRandomPlace();
            ConfigureEntity(ref cube);
            
            yield return wait;
        }
    }
    
    private Vector3 SelectRandomPlace()
    {
        return new Vector3(
            transform.position.x + Random.Range(-1.0f, 1.0f) * _radiusSpawn,
            transform.position.y,
            transform.position.z + Random.Range(-1.0f, 1.0f) * _radiusSpawn);
    }
}