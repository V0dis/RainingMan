using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class TransparencyChanger : MonoBehaviour
{
    const float MaxTransparency = 1f;
    const float MinTransparency = 0f;
    const float _minTimer = 2f; 
    const float _maxTimer = 5f;
    
    private Coroutine _transparencyChanging;
    
    public event Action BecameInvisible;

    private void OnDisable()
    {
        if (_transparencyChanging != null)
        {
            StopCoroutine(_transparencyChanging);
            _transparencyChanging = null;
        }
    }

    public void Change()
    {
        _transparencyChanging = StartCoroutine(ChangingColor());
    }

    private IEnumerator ChangingColor()
    {
        var renderer = GetComponent<Renderer>();
        
        if (renderer == null) 
            yield break;
        
        Color color = renderer.material.color;
        float elapsedTime = 0f;
        
        float timer = Random.Range(_minTimer, _maxTimer);
        
        while (elapsedTime <= timer)
        {
            elapsedTime += Time.deltaTime;
            
            color = renderer.material.color;
            color.a = Mathf.Lerp(MaxTransparency, MinTransparency, elapsedTime / timer);
            renderer.material.color = color;
            
            yield return null;
        }
        
        BecameInvisible?.Invoke();
    }
}