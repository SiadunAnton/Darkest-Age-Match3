using UnityEngine.Events;

public class RuleCreatorProcessor
{
    public event UnityAction OnRulesComplete;
    public void InvokeIfConditionIsTrue(bool condition)
    {
        if(!condition)
            return;
        OnRulesComplete?.Invoke();
    }
}