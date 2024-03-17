using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using Zenject;

public interface IRuleCreator
{
    event UnityAction OnRulesComplete;
    void StartChecking();
    ICompleteCondition WinCondition { get; set; }
}
public class RuleCreator : MonoBehaviour, IRuleCreator
{
    public event UnityAction OnRulesComplete
    {
        add { _processor.OnRulesComplete += value; }
        remove { _processor.OnRulesComplete -= value; }
    }
    public ICompleteCondition WinCondition { get; set; }

    private RandomRuleGenerator _generator;
    private RuleCreatorProcessor _processor;

    [Inject]
    public void Construct(RandomRuleGenerator ruleGenerator, RuleCreatorProcessor ruleCreatorProcessor)
    {
        
        _generator = ruleGenerator;
        _processor = ruleCreatorProcessor;
    }

    void Start()
    {
        WinCondition = _generator.Get();
        StartChecking();
    }
    
    public void StartChecking()
    {
        
        if (WinCondition == null)
            throw new NullReferenceException("WinRule value is empty.");
        StartCoroutine(CheckRuleProcess());
    }

    IEnumerator CheckRuleProcess()
    {
        for (; ; )
        {
            _processor.InvokeIfConditionIsTrue(WinCondition.isComplete());
            yield return new WaitForEndOfFrame();
        }
    }
}
