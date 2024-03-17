using System;

public class Rule
{
    public string Description;
    public Predicate<int> Condition;

    public Rule(string description, Predicate<int> condition)
    {
        Description = description;
        Condition = condition;
    }

    public bool IsComplete(int x)
    {
        return Condition(x);
    }
}
