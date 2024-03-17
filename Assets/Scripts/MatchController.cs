using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class MatchController : MonoBehaviour
{
    public UnityAction<List<GameObject>> OnMatch;
    
    private MergeChecker _checker;

    void Start()
    {
        _checker = new MergeChecker(gameObject, GetComponent<SpriteRenderer>().sprite);
        
    }

    public List<GameObject> GetMerged()
    {
        return _checker.GetMerged();
    }

    public void Match()
    {
        Debug.Log("Match");
        var merged = GetMerged();
        Score.Instance.AddScoreBySprite(_checker.Sprite, merged.Count);
        OnMatch?.Invoke(merged);
        RecreateTileGroup.RecreateGroup(merged);
    }
}
