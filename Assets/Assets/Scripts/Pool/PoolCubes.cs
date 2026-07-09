using UnityEngine;

public class PoolCubes : PoolEntity
{
    [SerializeField] protected Cube cube;

    private void Start()
    {
        Initialize(cube);
    }
}