using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Turn : MonoBehaviour
{
    public UnityAction OnTurnStart;
    public UnityAction OnTurnEnd;
    public int Current;

    [SerializeField] private Text _label;
    [SerializeField] private Swapper _swapper;

    private void Awake()
    {
        Current = 1;

        _swapper.OnSwapEnd += (x,y) =>
        {
            Debug.Log("Swap");
            OnTurnEnd?.Invoke();
            Next();
            OnTurnStart?.Invoke();
        };

        OnTurnEnd += TurnEndLog;
        OnTurnStart += TurnStartLog;

        StartCoroutine(Refresh());
    }

    private void Start()
    {
        OnTurnStart?.Invoke();
    }

    private void Next() => Current++;

    IEnumerator Refresh()
    { 
            yield return new WaitForEndOfFrame();
        for(; ; )
        {
            _label.text = Current.ToString();
            SetForfeit();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private void SetForfeit()
    {
        var forfeit = Mathf.FloorToInt(Current / 100) + 2;
        Score.Instance.Forfeit = forfeit;
    }

    private void TurnStartLog()
    {
        Debug.Log($"Turn{Current} Start");
    }

    private void TurnEndLog()
    {
        Debug.Log($"Turn{Current} End");
    }
}
