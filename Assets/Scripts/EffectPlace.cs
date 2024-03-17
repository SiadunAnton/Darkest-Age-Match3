using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectPlace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EffectSpawner _spawner;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_spawner.CanSpawn)
        {
            _spawner.SpawnEffect( transform);
        }
    }
}
