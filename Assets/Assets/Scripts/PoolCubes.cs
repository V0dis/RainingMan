using System.Collections.Generic;
using UnityEngine;

public class PoolCubes : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    
    private Stack<Cube> _poolCubes = new Stack<Cube>();
    private int _poolSize = 10;
    
    private void Awake()
    {
        CreatePool();
    }

    public Cube GetCube()
    {
        if (_poolCubes.Count == 0)
            CreateCube();

        Cube cube = _poolCubes.Pop();
        cube.gameObject.SetActive(true);
        return cube;
    }
    
    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
            CreateCube();
    }

    private void CreateCube()
    {
        Cube instance = Instantiate(_cube);
        instance.gameObject.SetActive(false);

        var cubeLifeCycle = instance.GetComponent<CubeLifeCycle>();
        
        if (cubeLifeCycle != null)
            cubeLifeCycle.isDeactivated += (cube) => Give(cube);
        
        _poolCubes.Push(instance);
    }

    private void Give(Cube cube)
    {
        _poolCubes.Push(cube);
    }
}