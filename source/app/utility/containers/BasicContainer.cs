using System;

namespace app.utility.containers
{
  public class BasicContainer : IFetchDependencies
  {
    IFindDependencyFactories factories;

    public BasicContainer(IFindDependencyFactories factories)
    {
      this.factories = factories;
    }

    public TDependency an<TDependency>()
    {
      return (TDependency) factories.get_the_factory_that_can_create(typeof(TDependency)).create();
    }

    public object an(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}