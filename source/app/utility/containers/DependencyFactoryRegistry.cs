using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.containers
{
  public class DependencyFactoryRegistry: IFindDependencyFactories
  {
    IEnumerable<ICreateOneDependency> factories;
    ICreateTheFactoryWhenDependencyFactoryIsNotFound special_case_factory;

    public DependencyFactoryRegistry(IEnumerable<ICreateOneDependency> factories, ICreateTheFactoryWhenDependencyFactoryIsNotFound special_case_factory)
    {
      this.factories = factories;
      this.special_case_factory = special_case_factory;
    }

    public ICreateOneDependency get_the_factory_that_can_create(Type dependency)
    {
      return factories.FirstOrDefault(x => x.can_create(dependency)) ?? special_case_factory(dependency);
    }
  }
}