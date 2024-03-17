using UnityEngine;
using System.Collections.Generic;
public class RandomRuleGenerator: MonoBehaviour
{
    [SerializeField] private List<DefiniedGameRule> _base;

    public DefiniedGameRule Get()
    {
        return _base[Random.Range(0,_base.Count)];
    }


}