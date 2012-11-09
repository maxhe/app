using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.containers
{
  public class DependencyFactoryRegistry: IFindDependencyFactories
  {
    IEnumerable<ICreateOneDependency> factories;

    public DependencyFactoryRegistry(IEnumerable<ICreateOneDependency> factories)
    {
      this.factories = factories;
    }

    public ICreateOneDependency get_the_factory_that_can_create(Type dependency)
    {
      return factories.First(x => x.can_create(dependency));
    }
  }
}