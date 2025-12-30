using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private PoolCubes _pool;
    [SerializeField] private float _radiusSpawn = 5f;
    [SerializeField] private float _interval = 2f;

    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnLoop());
    }
    
    private void OnDisable()
    {
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
    }

    private IEnumerator SpawnLoop()
    {
        var wait = new WaitForSeconds(_interval);
        
        while (enabled)
        {
            Cube cube = _pool.GetCube();
            cube.transform.position = SelectRandomPlace();
            cube.transform.rotation = Quaternion.identity;
            
            yield return wait;
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