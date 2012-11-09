using System;

namespace app.utility.containers
{
  public class DependencyFactoryRegistry: IFindDependencyFactories
  {
    public ICreateOneDependency get_the_factory_that_can_create(Type implementations)
    {
      throw new NotImplementedException();
    }
  }
}