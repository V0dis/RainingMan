using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private IEnumerator SpawnLoop()
    {
        var wait = new WaitForSeconds(_interval);
        
        while (enabled)
        {
            Cube cube = _pool.GetCube();
            
            cube.gameObject.SetActive(true);
            
            SubscribeToCube(cube);
            
            cube.transform.position = SelectRandomPlace();
            cube.transform.rotation = Quaternion.identity;
            
            yield return wait;
        }
    }

    private void SubscribeToCube(Cube cube)
    {
        if (cube.TryGetComponent(out CubeLifeCycle lifeCycle))
            lifeCycle.IsReadyToDeactivate += ReturnCube;
    }

    private void UnsubscribeToCube(Cube cube)
    {
        if (cube.TryGetComponent(out CubeLifeCycle lifeCycle))
            lifeCycle.IsReadyToDeactivate += ReturnCube;
    }

    private void ReturnCube(Cube cube)
    {
        if (!cube.gameObject.activeSelf) 
            return;
        
        cube.SetDefaultValue();
        UnsubscribeToCube(cube);
        cube.gameObject.SetActive(false);
        
        _pool.Return(cube);
    }

    private Vector3 SelectRandomPlace()
    {
        return new Vector3(
            transform.position.x + (Random.value - 0.5f) * 2 * _radiusSpawn,
            transform.position.y,
            transform.position.z + (Random.value - 0.5f) * 2 * _radiusSpawn);
    }
}