using UnityEngine;
using UnityEngine.UI;
public class RuleDescription : MonoBehaviour
{
    [SerializeField] private RuleCreator _ruleCreator;
    [SerializeField] private Text _field;

    private void Start()
    {
        InvokeRepeating("SetDescription",0f,0.2f);
    }
    
    private void SetDescription()
    {
        Rule rule = _ruleCreator.WinCondition.rule;
        _field.text = rule.Description;
    }
}
