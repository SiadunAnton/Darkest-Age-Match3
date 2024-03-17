using UnityEngine;

public class GetPointsOfTypeRule : DefiniedGameRule
{
    [SerializeField] private PointType _type;
    [SerializeField] private int _goalsValue = 0;

    public override bool isComplete()
    {
        switch(_type)
        {
            case PointType.Red:
                return rule.Condition(Score.Instance.Red);
            case PointType.Blue:
                return rule.Condition(Score.Instance.Blue);
            case PointType.White:
                return rule.Condition(Score.Instance.White);
            case PointType.Green:
                return rule.Condition(Score.Instance.Green);
        }
        return false;
    }

    private void Awake()
    {
        rule = new Rule(GetDescription(_type), x => x >= _goalsValue);
    }

    private string GetDescription(PointType pointType)
    {
        return "Get "+ _goalsValue +" "+ _type.ToString() +"  points";
    }
}
