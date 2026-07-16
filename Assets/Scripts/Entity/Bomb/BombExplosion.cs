using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 10f;

    public void Explode(Vector3 explosionCenter)
    {
        Collider[] hits = Physics.OverlapSphere(explosionCenter, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody == null)
                continue;
            
            hit.attachedRigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}