using System;

namespace app.utility.containers
{
  public class BasicContainer : IFetchDependencies
  {
    IFindDependencyFactories factories;
    ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem exception_factory;

      public BasicContainer(IFindDependencyFactories factories, ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem exception_factory)
    {
        this.factories = factories;
        this.exception_factory = exception_factory;
    }

      public TDependency an<TDependency>()
    {
        try
        {
            return (TDependency) factories.get_the_factory_that_can_create(typeof(TDependency)).create();
        }
        catch (Exception e)
        {
           throw exception_factory(typeof(TDependency), e);
        }
        
    }

    public object an(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}