using UnityEngine;

public abstract class DefiniedGameRule : MonoBehaviour, ICompleteCondition
{
    public Rule rule { get; set; }

    public abstract bool isComplete();
}


