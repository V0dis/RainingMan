using System.Collections;
using UnityEngine;

public class CubeSpawner : SpawnerGeneric<Cube>
{
    [SerializeField] private float _interval = 2f;
    [SerializeField] private float _radiusSpawn = 5f;
    [SerializeField] private BombSpawner _bombSpawner;
    
    Coroutine _spawnRoutine;
    
    private void Start()
    {
        _spawnRoutine = StartCoroutine(SpawnLoopCubes());
    }

    protected override void OnReturning(Cube cube)
    {
        _bombSpawner.SpawnBomb(cube);
    }

    private IEnumerator SpawnLoopCubes()
    {
        var wait = new WaitForSeconds(_interval);
        
        while (enabled)
        {
            if (PoolEntity.Get().TryGetComponent(out Cube cube))
            {
                cube.transform.rotation = Quaternion.identity;
                cube.transform.position = SelectRandomPlace();

                ConfigureEntity(ref cube);

                yield return wait;
            }
        }
    }
    
    private Vector3 SelectRandomPlace()
    {
        return new Vector3(
            transform.position.x + (Random.value - 0.5f) * 2 * _radiusSpawn,
            transform.position.y,
            transform.position.z + (Random.value - 0.5f) * 2 * _radiusSpawn);
    }
}

