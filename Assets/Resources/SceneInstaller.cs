using Zenject;

public class SceneInstaller : MonoInstaller
{
    public RuleCreator RuleCreator;
    public EndGameDetector EndGameDetector;
    public override void InstallBindings()
    {
        BindRuleCreator();
        BindEndGameDetector();
    }
    
    private void BindRuleCreator()
    {
        Container
            .BindInterfacesAndSelfTo<IRuleCreator>()
            .FromInstance(RuleCreator)
            .AsSingle();
        
    }

    private void BindEndGameDetector()
    {
        Container
            .Bind<EndGameDetector>()
            .FromInstance(EndGameDetector)
            .AsSingle();
    }
}
