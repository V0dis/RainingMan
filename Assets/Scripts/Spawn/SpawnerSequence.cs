using System;
using UnityEngine;

public class SpawnerSequence : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void OnEnable()
    {
        _cubeSpawner.IsReturning += StartBombSpawn;
    }

    private void OnDisable()
    {
        _cubeSpawner.IsReturning -= StartBombSpawn;
    }

    private void StartBombSpawn(Cube cube)
    {
        _bombSpawner.SpawnBomb(cube);
    }
}