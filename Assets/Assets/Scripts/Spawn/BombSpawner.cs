using UnityEngine;

public class BombSpawner : SpawnerGeneric<Bomb>
{
    public void SpawnBomb(Cube cube)
    {
        if (PoolEntity.Get().TryGetComponent(out Bomb bomb))
        {
            bomb.transform.rotation = cube.transform.rotation;
            bomb.transform.position = cube.transform.position;

            if (bomb.TryGetComponent(out Rigidbody bombRigidbody) && cube.TryGetComponent(out Rigidbody cubeRigidbody))
                bombRigidbody.linearVelocity = cubeRigidbody.linearVelocity;

            ConfigureEntity(ref bomb);
        }
    }
}


