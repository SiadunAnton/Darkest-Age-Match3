using UnityEngine;

public class CheckMergeAfterSwap : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Swapper _swapper;
    private Scoring _scoring;

    private void Awake()
    {
        _scoring = FindObjectOfType<Scoring>();
        _swapper = GetComponent<Swapper>();
        _swapper.OnSwapEnd += CheckMergeWhenSwap;
    }

    private void CheckMergeWhenSwap(GameObject first,GameObject second)
    {
        var isFirstMatched = CheckMatch(first);
        var isSecondMatched = CheckMatch(second);

        MatchProcessor.Instance.AddController(first.GetComponent<MatchController>());
        MatchProcessor.Instance.AddController(second.GetComponent<MatchController>());

        if ( !isFirstMatched && !isSecondMatched)
        {
            _score.Penalty();
            _scoring.Fine();
        }
    }

    private bool CheckMatch(GameObject target)
    {
        return MatchAnalizer.IsMatch(target.GetComponent<MatchController>().GetMerged());
    }

}
