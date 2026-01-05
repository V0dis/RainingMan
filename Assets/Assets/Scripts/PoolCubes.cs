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
        return cube;
    }
    
    public void Return(Cube cube)
    {
       _poolCubes.Push(cube);
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
        
        _poolCubes.Push(instance);
    }
}