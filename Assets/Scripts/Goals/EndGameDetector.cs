using UnityEngine;
using Zenject;
using UnityEngine.Events;

public sealed class EndGameDetector : MonoBehaviour
{    
    public event UnityAction OnWin;
    public event UnityAction OnLose;

    private IRuleCreator _ruleCreator;

    [Inject]
    public void Construct(IRuleCreator ruleCreator)
    {
        _ruleCreator = ruleCreator;
    } 

    private void Update()
    {
        NotifyIfLose();
        NotifyIfWin();
    }

    public void NotifyIfWin()
    {
        if(_ruleCreator.WinCondition.isComplete())
            OnWin?.Invoke();
    }

    public void NotifyIfLose()
    {
        if(Score.Instance.isLost())
            OnLose?.Invoke();
    }
}
