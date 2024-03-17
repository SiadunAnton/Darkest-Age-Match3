using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    public bool CanSpawn = false;

    public void SpawnEffect(Transform target)
    { 
        var effect = Instantiate(_particlePrefab, target);
        var priest = target.gameObject.AddComponent<PriestMerge>();
        priest.BindWithTile(target.gameObject, effect);
        CanSpawn = false;
    }

    public void AllowSpawn()
    {
        if (Score.Instance.Blue >= 20)
        {
            Score.Instance.BuyForBluePoints(20);
            CanSpawn = true;
        }
    }
}
