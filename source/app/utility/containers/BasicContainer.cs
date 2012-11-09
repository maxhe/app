using System;

namespace app.utility.containers
{
  public class BasicContainer : IFetchDependencies
  {
    IFindDependencyFactories factories;
    ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem exception_factory;

    public BasicContainer(IFindDependencyFactories factories,
                          ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem exception_factory)
    {
      this.factories = factories;
      this.exception_factory = exception_factory;
    }

    public TDependency an<TDependency>()
    {
      return (TDependency) an(typeof(TDependency));
    }

    public object an(Type dependency)
    {
      return SyntaxSugar.to_run(factories.get_the_factory_that_can_create(dependency).create)
        .on_error(e => exception_factory(dependency, e))
        .run();
    }
  }
}