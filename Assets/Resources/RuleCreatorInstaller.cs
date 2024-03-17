using Zenject;

public class RuleCreatorInstaller : MonoInstaller
{
    public RandomRuleGenerator RuleGenerator;
    public override void InstallBindings()
    {
        BindRandomRuleGenerator();
        BindRuleCreatorProcess();
    }

    private void BindRandomRuleGenerator()
    {
        Container
            .Bind<RandomRuleGenerator>()
            .FromInstance(RuleGenerator)
            .AsSingle();
    }

    private void BindRuleCreatorProcess()
    {
        Container.Bind<RuleCreatorProcessor>()
            .FromInstance(new RuleCreatorProcessor());
    }
}