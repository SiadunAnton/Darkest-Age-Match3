public interface ICompleteCondition
{
    public bool isComplete();
    public Rule rule { get; set; }
}