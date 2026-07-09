using System;
using Unity.VisualScripting;
using UnityEngine;

public class BombLifeCycle : EntityLifeCycle
{
    [SerializeField] private TransparencyChanger _transparencyChanger;
    [SerializeField] private BombExplosion _bombExplosion;
    
    private void OnEnable()
    {
        _transparencyChanger.BecameInvisible += Explode;
        _transparencyChanger.BecameInvisible += Return;
    }

    protected override void IsInitialized()
    {
        _transparencyChanger.Change();
    }

    private void OnDisable()
    { 
        _transparencyChanger.BecameInvisible -= Explode;
        _transparencyChanger.BecameInvisible -= Return;
    }

    private void Explode()
    {
        _bombExplosion.Explode(transform.position);
    }
}
