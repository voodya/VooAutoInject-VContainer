using VContainer;
using VContainer.Unity;

public class CustomScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InjectedServiceExample>(Lifetime.Singleton).As<IService>();
    }
}
