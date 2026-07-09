using TMPro;
using UnityEngine;

public class UICount : MonoBehaviour 
{
    [SerializeReference] private PoolEntity _poolEntity;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _poolEntity.CountChanged += UpdateCount;
    }

    private void OnDisable()
    {
        _poolEntity.CountChanged -= UpdateCount;
    }
    
    public void UpdateCount()
    {
        _text.text = "Active: " + _poolEntity.CountActive 
                    +"\nSpawned: " + _poolEntity.SpawnedCount
                    + "\nCreated: " + _poolEntity.CreatedCount;
    }
}