using UnityEngine;

public class PoolBombs : PoolEntity
{
    [SerializeField] private Bomb bomb;

    private void Start()
    {
        Initialize(bomb);
    }
}